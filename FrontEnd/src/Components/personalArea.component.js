import React from "react";

const PersonalAreaComponent = ({ personalArea }) => {
    return (
        <div>
            <h2>Personal Information</h2>
            {personalArea.email && <p>Email: {personalArea.email}</p>}
            {personalArea.name && <p>Name: {personalArea.name}</p>}
            {personalArea.age && <p>Age: {personalArea.age}</p>}
        </div>
    );
};

export default PersonalAreaComponent;