import React from "react";
import { useNavigate } from "react-router-dom";

const HomeComponent = () => {
    const navigate = useNavigate();

    const navigateToLogin = () => {
        navigate("/connection");
    };

    const navigateToRegister = () => {
        navigate("/register");
    };

    return (
        <div>
            <h2>Welcome to CoHousing!!</h2>
            <div>
            <label>כבר חבר במערכת?</label>
            <button onClick={navigateToLogin}>Login</button>
            </div>
            <div>
            <label>עדיין אין לך חשבון?</label>
            <button onClick={navigateToRegister}>Register</button>
            </div>
        </div>
    );
};

export default HomeComponent;