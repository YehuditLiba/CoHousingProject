import React, { useState } from 'react';
import '../Designs/accessibility.css'; // הקובץ CSS שמכיל את העיצוב של רכיב הנגישות

const AccessibilityMenu = () => {
    const [isMenuOpen, setIsMenuOpen] = useState(false);

    const toggleMenu = () => {
        setIsMenuOpen(!isMenuOpen);
    };

    const increaseTextSize = () => {
        document.body.style.fontSize = 'larger';
    };

    const decreaseTextSize = () => {
        document.body.style.fontSize = 'smaller';
    };

    const reset = () => {
        document.body.style.fontSize = ''; //reset font size
        document.body.style.backgroundColor = '#f0f0f0'; //reset background color
        document.body.style.color = '#0b0201'; //reset color
    };

    const setLightBackground = () => {
        document.body.style.backgroundColor = '#fff';
        document.body.style.color = '#000';
    };

    const setDarkBackground = () => {
        document.body.style.backgroundColor = '#333';
        document.body.style.color = '#fff';
    };

    return (
        <div className="accessibility-menu">
            <button className="accessibility-icon" onClick={toggleMenu}><img src="/neche.png" alt="Logo" className='accessImg'/></button>
            {isMenuOpen && (
                <div className="accessibility-options">
                    <button onClick={increaseTextSize}>הגדל טקסט</button>
                    <button onClick={decreaseTextSize}>הקטן טקסט</button>
                    <button onClick={setLightBackground}>רקע בהיר</button>
                    <button onClick={setDarkBackground}>רקע כהה</button>
                    <button onClick={reset}>איפוס </button>
                </div>
            )}
        </div>
    );
};

export default AccessibilityMenu;
