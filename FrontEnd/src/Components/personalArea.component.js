import React, { useState } from "react";
import { useLocation } from "react-router-dom";
import '../Designs/personalArea.css'; 
import AddProposalDialog from './addProposalDialog.component'; 

const PersonalAreaComponent = () => {
    const location = useLocation();
    const { personalArea } = location.state || {};
    const [isDialogOpen, setIsDialogOpen] = useState(false);

    const handleAddProposal = (newProposal) => {
        const queryParams = new URLSearchParams({
            id: newProposal.tenantId,
            description: newProposal.proposalDescription
        });

        const url = `http://localhost:5013/api/proposals?${queryParams.toString()}`;

        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            }
        })
        .then(response => response.json())
        .then(data => {
            console.log('Success:', data);
            // עדכון הרשימה המקומית של ההצעות לאחר שמירת ההצעה החדשה
            if (personalArea && personalArea.proposals) {
                personalArea.proposals.push(data);
            }
        })
        .catch((error) => {
            console.error('Error:', error);
        });
    };

    return (
        <div className="personal-area-container">
            <h2>Hi, {personalArea.name}</h2>
            <div className="personal-details">
                {personalArea && personalArea.email && <p>Email: {personalArea.email}</p>}
                {personalArea && personalArea.apartmentNumber && <p>Apartment Number: {personalArea.apartmentNumber}</p>}
                {personalArea && personalArea.phone && <p>Phone Number: {personalArea.phone}</p>}
                {personalArea && personalArea.balance && <p>Balance: {personalArea.balance}</p>}
            </div>

            <div className="proposals">
                <h3>Proposals</h3>
                <ul>
                    {personalArea && personalArea.proposals && personalArea.proposals.length > 0 
                        ? personalArea.proposals.map((proposal, index) => (
                            <li key={index}>{proposal}</li>
                          ))
                        : <li>No proposals available.</li>
                    }
                </ul>
                <button className="add-proposal-btn" onClick={() => setIsDialogOpen(true)}>+</button>
            </div>

            {personalArea && personalArea.isCommitee !== undefined && (
                personalArea.isCommitee 
                ? <p>You are a committee member.</p> 
                : <p>You are not a committee member.</p>
            )}

            {/* {personalArea && personalArea.isCommitee && (
                <div className="committee-actions">
                    <button>Add Tenant</button>
                    <button>Delete Tenant</button>
                </div>
            )} */}

            {isDialogOpen && (
                <AddProposalDialog 
                    onClose={() => setIsDialogOpen(false)} 
                    onSave={handleAddProposal} 
                />
            )}
        </div>
    );
};

export default PersonalAreaComponent;
