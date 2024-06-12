import React, { useEffect, useState } from "react";

const ConnectionComponent = () => {
    const [tenants, setTenants] = useState([]);

    useEffect(() => {
        const url = "http://localhost:5013/api/tenant/1002";

        const fetchData = async () => {
            try {
                const response = await fetch(url, {
                    method: 'GET',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    credentials: 'include'
                });

                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }

                const data = await response.json();
                setTenants(data);
            } catch (error) {
                console.error("Error fetching data:", error);
            }
        };

        fetchData();
    }, []);

    return (
        <div>
            <h1>Tenants Information</h1>
            {tenants.length > 0 ? (
                <table>
                    <thead>
                        <tr>
                            <th>Tenant ID</th>
                            <th>Full Name</th>
                            <th>Phone Number</th>
                            <th>Email Address</th>
                            <th>Balance</th>
                            <th>Is Committee</th>
                        </tr>
                    </thead>
                    <tbody>
                        {tenants.map((tenant) => (
                            <tr key={tenant.tenantId}>
                                <td>{tenant.tenantId}</td>
                                <td>{tenant.fullName}</td>
                                <td>{tenant.phoneNumber}</td>
                                <td>{tenant.emailAddress}</td>
                                <td>{tenant.balance}</td>
                                <td>{tenant.isCommitee ? 'Yes' : 'No'}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            ) : (
                <p>Loading...</p>
            )}
        </div>
    );
};

export default ConnectionComponent;

