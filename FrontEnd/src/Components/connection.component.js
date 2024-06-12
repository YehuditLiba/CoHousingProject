// import React, { useState } from "react";
// import PersonalArea from "./personalArea.component.js";

// const ConnectionComponent = () => {
//     const [email, setEmail] = useState('');
//     const [password, setPassword] = useState('');
//     const [isLoading, setIsLoading] = useState(false);
//     const [error, setError] = useState(null);
//     const [personalArea, setPersonalArea] = useState(null);

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
//             console.log(data); // Handle the response data as needed
//             setPersonalArea(data.PersonalAreaComponent); // Assuming the response contains personal information
//         } catch (error) {
//             console.error("Error fetching data:", error);
//             setError(`Failed to fetch data: ${error.message}`);
//         } finally {
//             setIsLoading(false);
//         }
//     };

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
//             {personalArea && <PersonalArea personalArea={personalArea} />}
//         </div>
//     );
// };

// export default ConnectionComponent;

import React, { useState } from "react";
import PersonalArea from "./personalArea.component.js";

const ConnectionComponent = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState(null);
    const [isLoggedIn, setIsLoggedIn] = useState(false); // משתנה חדש לצורך הבדיקה האם המשתמש מחובר
    const [personalInfo, setPersonalInfo] = useState(null); // משתנה לשמירת מידע אישי

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
            console.log(data); // Handle the response data as needed
            setPersonalInfo(data.PersonalAreaComponent); // Assuming the response contains personal information
            setIsLoggedIn(true); // הגדרת המשתנה isLoggedIn ל true לאחר ההצלחה בהתחברות
        } catch (error) {
            console.error("Error fetching data:", error);
            setError(`Failed to fetch data: ${error.message}`);
        } finally {
            setIsLoading(false);
        }
    };

    return (
        <div>
            <h1>Login Form</h1>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>Email:</label>
                    <input type="email" value={email} onChange={handleEmailChange} required />
                </div>
                <div>
                    <label>Password:</label>
                    <input type="password" value={password} onChange={handlePasswordChange} required />
                </div>
                <button type="submit" disabled={isLoading}>Submit</button>
            </form>
            {isLoading && <p>Loading...</p>}
            {error && <p>{error}</p>}
            {/* הצגת הקומפוננטה רק אם המשתנה isLoggedIn הוא true */}
            {isLoggedIn && personalInfo && <PersonalArea personalInfo={personalInfo} />}
        </div>
    );
};

export default ConnectionComponent;