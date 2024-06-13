import React, { useState } from "react";

const RegisterComponent = () => {
    const [formData, setFormData] = useState({
        idNumber: "",
        buildingNumber: "",
        apartmentNumber: "",
        firstName: "",
        lastName: "",
        phoneNumber: "",
        username: "",
        password: "",
        balance: "0",
        isCommitteeMember: false
    });

    const [formErrors, setFormErrors] = useState({});

    const handleChange = (e) => {
        const value = e.target.type === "checkbox" ? e.target.checked : e.target.value;
        setFormData({
            ...formData,
            [e.target.name]: value
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        const errors = validateForm(formData);
        if (Object.keys(errors).length > 0) {
            setFormErrors(errors);
            return;
        }

        try {
            const response = await fetch("http://localhost:5013/tenant/register", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(formData)
            });

            if (response.ok) {
                console.log("נוספת בהצלחה למאגר.");
            } else {
                console.error("Failed to register.");
            }
        } 
        catch (error) {
            console.error("Error:", error);
            // ניתן להוסיף פה התראה למשתמש על כישלון ברשת או בבקשה
        }
    };

    const validateForm = (formData) => {
        let errors = {};

        if (!formData.idNumber) {
            errors.idNumber = "מספר זהות הינו שדה חובה";
        }

        // if (!formData.buildingNumber) {
        //     errors.buildingNumber = "מספר בנין הינו שדה חובה";
        // }

        if (!formData.apartmentNumber) {
            errors.apartmentNumber = "מספר דירה הינו שדה חובה";
        }

        if (!formData.firstName) {
            errors.firstName = "שם פרטי הינו שדה חובה";
        }

        if (!formData.lastName) {
            errors.lastName = "שם משפחה הינו שדה חובה";
        }

        if (!formData.phoneNumber) {
            errors.phoneNumber = "מספר טלפון הינו שדה חובה";
        }

        // if (!formData.username) {
        //     errors.username = "שם משתמש הינו שדה חובה";
        // }

        if (!formData.password) {
            errors.password = "סיסמה הינה שדה חובה";
        }

        // if (!formData.balance) {
        //     errors.balance = "יתרה היא שדה חובה";
        // } else if (isNaN(formData.balance)) {
        //     errors.balance = "יש להזין סכום חוקי";
        // }

        return errors;
    };

    return (
        <div>
            <h2>הרשמה למערכת</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>מספר זהות:</label>
                    <input
                        type="text"
                        name="idNumber"
                        value={formData.idNumber}
                        onChange={handleChange}
                        required
                    />
                    {formErrors.idNumber && <span>{formErrors.idNumber}</span>}
                </div>

                {/* <div>
                    <label>מספר בנין:</label>
                    <input
                        type="text"
                        name="buildingNumber"
                        value={formData.buildingNumber}
                        onChange={handleChange}
                        required
                    />
                    {formErrors.buildingNumber && <span>{formErrors.buildingNumber}</span>}
                </div> */}

                <div>
                    <label>מספר דירה:</label>
                    <input
                        type="text"
                        name="apartmentNumber"
                        value={formData.apartmentNumber}
                        onChange={handleChange}
                        required
                    />
                    {formErrors.apartmentNumber && <span>{formErrors.apartmentNumber}</span>}
                </div>

                <div>
                    <label>שם פרטי:</label>
                    <input
                        type="text"
                        name="firstName"
                        value={formData.firstName}
                        onChange={handleChange}
                        required
                    />
                    {formErrors.firstName && <span>{formErrors.firstName}</span>}
                </div>

                <div>
                    <label>שם משפחה:</label>
                    <input
                        type="text"
                        name="lastName"
                        value={formData.lastName}
                        onChange={handleChange}
                        required
                    />
                    {formErrors.lastName && <span>{formErrors.lastName}</span>}
                </div>

                <div>
                    <label>מספר טלפון:</label>
                    <input
                        type="text"
                        name="phoneNumber"
                        value={formData.phoneNumber}
                        onChange={handleChange}
                        required
                    />
                    {formErrors.phoneNumber && <span>{formErrors.phoneNumber}</span>}
                </div>

                {/* <div>
                    <label>שם משתמש:</label>
                    <input
                        type="text"
                        name="username"
                        value={formData.username}
                        onChange={handleChange}
                        required
                    />
                    {formErrors.username && <span>{formErrors.username}</span>}
                </div> */}

                <div>
                    <label>סיסמה:</label>
                    <input
                        type="password"
                        name="password"
                        value={formData.password}
                        onChange={handleChange}
                        required
                    />
                    {formErrors.password && <span>{formErrors.password}</span>}
                </div>

                <div>
                    <label>יתרה:</label>
                    <input
                        type="text"
                        name="balance"
                        value={formData.balance}
                        onChange={handleChange}
                        required
                    />
                    {formErrors.balance && <span>{formErrors.balance}</span>}
                </div>

                <div>
                    <label>
                        האם וועד בית?
                        <input
                            type="checkbox"
                            name="isCommitteeMember"
                            checked={formData.isCommitteeMember}
                            onChange={handleChange}
                        />
                    </label>
                </div>

                <button type="submit">רישום</button>
            </form>
        </div>
    );
};

export default RegisterComponent;
