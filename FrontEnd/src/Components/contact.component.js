import React, { useState } from "react";
import '../Designs/contact.css';

const ContactComponent = () => {
    const [name, setName] = useState('');
    const [phone, setPhone] = useState('');
    const [email, setEmail] = useState('');
    const [message, setMessage] = useState('');

    const handleSubmit = (event) => {
        event.preventDefault();
        // הוסף כאן את הלוגיקה לשליחת הטופס
        console.log('Submitted:', { name, phone, email, message });
    };

    return (
        <div className="contact-container">
            <h2 className="title">נשמח לעמוד בקשר!</h2>
            <form onSubmit={handleSubmit} className="contact-form">
                <div className="form-group">
                    <input type="text" id="name" value={name} placeholder="Name" onChange={(e) => setName(e.target.value)} required />
                </div>
                <div className="form-group">
                    <input type="tel" id="phone" value={phone} placeholder="Phone" onChange={(e) => setPhone(e.target.value)} required />
                </div>
                <div className="form-group">
                    <input type="email" id="email" value={email} placeholder="email" onChange={(e) => setEmail(e.target.value)} required />
                </div>
                <div className="form-group">
                    <textarea id="message" value={message} placeholder="somthing you want to tell us..." onChange={(e) => setMessage(e.target.value)} ></textarea>
                </div>
                <button type="submit" className="submit-button">Submit</button>
            </form>
        </div>
    );
};

export default ContactComponent;
