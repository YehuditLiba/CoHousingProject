// import React from "react";
// import { useNavigate } from "react-router-dom";

// const HomeComponent = () => {
//     const navigate = useNavigate();

//     const navigateToLogin = () => {
//         navigate("/connection");
//     };

//     const navigateToRegister = () => {
//         navigate("/register");
//     };

//     return (
//         <div>
//             <h2>Welcome to CoHousing!!</h2>
//             <div>
//             <label>כבר חבר במערכת?</label>
//             <button onClick={navigateToLogin}>Login</button>
//             </div>
//             <div>
//             <label>עדיין אין לך חשבון?</label>
//             <button onClick={navigateToRegister}>Register</button>
//             </div>
//         </div>
//     );
// };

// export default HomeComponent;

import React from "react";
import { useNavigate } from "react-router-dom";
import '../Designs/home.css'; 

const HomeComponent = () => {
    const navigate = useNavigate();

    const navigateToLogin = () => {
        navigate("/connection");
    };

    const navigateToRegister = () => {
        navigate("/register");
    };

    return (
        <div className="home-background">
            <div className="home-container">
                <h1>Welcome to CoHousing!!</h1>
                <div className="boxes-container">
                    <div className="floating-box" onClick={navigateToLogin}>
                        <label>כבר חבר במערכת?</label>
                        <button>Login</button>
                    </div>
                    <div className="floating-box" onClick={navigateToRegister}>
                        <label>עדיין אין לך חשבון?</label>
                        <button>Register</button>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default HomeComponent;