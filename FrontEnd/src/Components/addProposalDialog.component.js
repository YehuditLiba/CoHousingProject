import React, { useState } from "react";

const AddProposalDialog = ({ onClose, onSave }) => {
    const [tenantId, setTenantId] = useState("");
    const [proposalDescription, setProposalDescription] = useState("");

    const handleSave = () => {
        const newProposal = {
            tenantId,
            proposalDescription,
        };
        onSave(newProposal);
        onClose();
    };

    return (
        <div className="dialog-overlay">
            <div className="dialog">
                <h2>Add New Proposal</h2>
                <div className="form-group">
                    <label>Tenant ID:</label>
                    <input
                        type="text"
                        value={tenantId}
                        onChange={(e) => setTenantId(e.target.value)}
                    />
                </div>
                <div className="form-group">
                    <label>Proposal Description:</label>
                    <textarea
                        value={proposalDescription}
                        onChange={(e) => setProposalDescription(e.target.value)}
                    />
                </div>
                <div className="dialog-actions">
                    <button onClick={onClose}>Cancel</button>
                    <button onClick={handleSave}>Save</button>
                </div>
            </div>
        </div>
    );
};

export default AddProposalDialog;
