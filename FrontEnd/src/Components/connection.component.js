// import React, { useState, useEffect } from "react";
// import { useNavigate } from "react-router-dom";
// import PersonalArea from "./personalArea.component.js";
// import '../Designs/connection.css';

// const ConnectionComponent = () => {
//     const navigate = useNavigate();

//     const [email, setEmail] = useState('');
//     const [password, setPassword] = useState('');
//     const [isLoading, setIsLoading] = useState(false);
//     const [error, setError] = useState(null);
//     const [isLoggedIn, setIsLoggedIn] = useState(false); 
//     const [personalInfo, setPersonalInfo] = useState(null); 

//     const handleEmailChange = (event) => {
//         setEmail(event.target.value);
//     };

//     const handlePasswordChange = (event) => {
//         setPassword(event.target.value);
//     };

//     const handleSubmit = async (event) => {
//         event.preventDefault();
//         setIsLoading(true);
//         setError(null);

//         try {
//             const url = "http://localhost:5013/api/tenant/login";
//             const response = await fetch(url, {
//                 method: 'POST',
//                 headers: {
//                     'Content-Type': 'application/json'
//                 },
//                 credentials: 'include',
//                 body: JSON.stringify({ email, password })
//             });

//             if (!response.ok) {
//                 const errorText = await response.text();
//                 console.error(`Network response was not ok: ${response.status} - ${response.statusText}`);
//                 console.error(`Response Error Text: ${errorText}`);
//                 throw new Error(`Network response was not ok: ${response.status} - ${response.statusText}`);
//             }

//             const data = await response.json();
//             const personalAreaData = {
//                 email: data.email,
//                 name: data.name,
//                 age: data.age
//             };

//             // Set personalInfo state
//             setPersonalInfo(personalAreaData);
//             setIsLoggedIn(true);
//         } catch (error) {
//             console.error("Error fetching data:", error);
//             setError(`Failed to fetch data: ${error.message}`);
//         } finally {
//             setIsLoading(false);
//         }
//     };

//     // useEffect for navigation to PersonalArea after successful login
//     useEffect(() => {
//         if (isLoggedIn && personalInfo) {
//             navigate("/personal-area", { state: { personalArea: personalInfo } });
//         }
//     }, [isLoggedIn, personalInfo, navigate]);

//     return (
//         <div>
//             <h1>Login Form</h1>
//             <form onSubmit={handleSubmit}>
//                 <div>
//                     <label>Email:</label>
//                     <input type="email" value={email} onChange={handleEmailChange} required />
//                 </div>
//                 <div>
//                     <label>Password:</label>
//                     <input type="password" value={password} onChange={handlePasswordChange} required />
//                 </div>
//                 <button type="submit" disabled={isLoading}>Submit</button>
//             </form>
//             {isLoading && <p>Loading...</p>}
//             {error && <p>{error}</p>}
//             {/* Display PersonalArea component only if user is logged in */}
//             {isLoggedIn && personalInfo && <PersonalArea personalInfo={personalInfo} />}
//         </div>
//     );
// };

// export default ConnectionComponent;

import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import PersonalArea from "./personalArea.component.js";
import '../Designs/connection.css'; // ייבוא קובץ ה-CSS

const ConnectionComponent = () => {
    const navigate = useNavigate();

    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState(null);
    const [isLoggedIn, setIsLoggedIn] = useState(false); 
    const [personalInfo, setPersonalInfo] = useState(null); 

    const handleEmailChange = (event) => {
        setEmail(event.target.value);
    };

    const handlePasswordChange = (event) => {
        setPassword(event.target.value);
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        setIsLoading(true);
        setError(null);

        try {
            const url = "http://localhost:5013/api/tenant/login";
            const response = await fetch(url, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                credentials: 'include',
                body: JSON.stringify({ email, password })
            });

            if (!response.ok) {
                const errorText = await response.text();
                console.error(`Network response was not ok: ${response.status} - ${response.statusText}`);
                console.error(`Response Error Text: ${errorText}`);
                throw new Error(`Network response was not ok: ${response.status} - ${response.statusText}`);
            }

            const data = await response.json();
            const personalAreaData = {
                email: data.email,
                name: data.name,
                age: data.age
            };

            // Set personalInfo state
            setPersonalInfo(personalAreaData);
            setIsLoggedIn(true);
        } catch (error) {
            console.error("Error fetching data:", error);
            setError(`Failed to fetch data: ${error.message}`);
        } finally {
            setIsLoading(false);
        }
    };

    // useEffect for navigation to PersonalArea after successful login
    useEffect(() => {
        if (isLoggedIn && personalInfo) {
            navigate("/personal-area", { state: { personalArea: personalInfo } });
        }
    }, [isLoggedIn, personalInfo, navigate]);

    return (
        <div className="form-container">
            <form onSubmit={handleSubmit}>
                <h1>Login Form</h1>
                <div className="form-group">
                    <input
                        type="email"
                        value={email}
                        onChange={handleEmailChange}
                        placeholder=" "
                        required
                    />
                    <label>Email:</label>
                </div>
                <div className="form-group">
                    <input
                        type="password"
                        value={password}
                        onChange={handlePasswordChange}
                        placeholder=" "
                        required
                    />
                    <label>Password:</label>
                </div>
                <button type="submit" disabled={isLoading}>Submit</button>
                {isLoading && <p>Loading...</p>}
                {error && <p>{error}</p>}
                {/* Display PersonalArea component only if user is logged in */}
                {isLoggedIn && personalInfo && <PersonalArea personalInfo={personalInfo} />}
            </form>
        </div>
    );
};

export default ConnectionComponent;
