// import React from "react";
// import { useLocation } from "react-router-dom";

// const PersonalAreaComponent = () => {
//     const location = useLocation();
//     const { personalArea } = location.state;

//     return (
//         <div>
//             <h2>Personal Information</h2>
//             {personalArea.email && <p>Email: {personalArea.email}</p>}
//             {personalArea.name && <p>Name: {personalArea.name}</p>}
//             {personalArea.age && <p>Age: {personalArea.age}</p>}
//         </div>
//     );
// };

// export default PersonalAreaComponent;


import React from "react";
import { useLocation } from "react-router-dom";

const PersonalAreaComponent = () => {
    const location = useLocation();
    const { personalArea } = location.state || {};

    return (
        <div>
            <h2>Personal Information</h2>
            {personalArea && personalArea.email && <p>Email: {personalArea.email}</p>}
            {personalArea && personalArea.name && <p>Name: {personalArea.name}</p>}
            {personalArea && personalArea.age && <p>Age: {personalArea.age}</p>}
        </div>
    );
};

export default PersonalAreaComponent;