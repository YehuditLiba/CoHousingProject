import React from "react";
import { Link } from "react-router-dom";
import '../Designs/navbar.css';

function Navbar() {
    return (
        <nav>
            <ul>
                <li ><Link to="/"><img src="/logo.png" alt="Logo" /></Link></li>
                <li className="navItem"><Link to="/contact">צור קשר</Link></li>
                <li className="navItem"><Link to="/faq">שאלות ותשובות</Link></li>
                <li className="navItem"><Link to="/connection">התחברות</Link></li>
                <li className="navItem"><Link to="/register">הרשמה</Link></li>
                <li className="navItem"><Link to="/about">אודותינו</Link></li>
                <li className="navItem"><Link to="/">ראשי</Link></li>
            </ul>
        </nav>
    );
}

export default Navbar;
