import React, { useState } from "react";
import '../Designs/faq.css'; // Import the CSS file

const FAQComponent = () => {
    const [activeIndex, setActiveIndex] = useState(null);

    const toggleAnswer = (index) => {
        setActiveIndex(activeIndex === index ? null : index);
    };

    const faqs = [
        { question: "מהו תפקיד ועד הבית?", answer: "ועד הבית אחראי על ניהול ותחזוקת הרכוש המשותף בבניין, כולל ניקיון, תיקונים, גביית דמי ועד ועוד." },
        { question: "איך בוחרים ועד בית?", answer: "ועד הבית נבחר באסיפת דיירים על פי רוב קולות." },
        { question: "מהם דמי ועד הבית?", answer: "דמי ועד הבית הם תשלום חודשי המשולם על ידי הדיירים לצורך תחזוקת הבניין והשטחים המשותפים." },
        { question: "מה קורה אם דייר מסרב לשלם דמי ועד?", answer: "במקרה כזה, ועד הבית רשאי לנקוט בהליכים משפטיים לגביית החוב." },
        { question: "מה כולל תפקידי ועד הבית?", answer: "תפקידי ועד הבית כוללים בין היתר: תחזוקה שוטפת, טיפול בתקלות, ניהול הכספים ואחריות על ניקיון השטחים המשותפים." },
        { question: "כמה זמן נמשך כהונת ועד הבית?", answer: "כהונת ועד הבית נמשכת לרוב שנה, אך ניתן להאריך או לקצר בהתאם להחלטת הדיירים באסיפה." },
        { question: "האם ניתן להחליף חבר ועד במהלך השנה?", answer: "כן, באסיפת דיירים מיוחדת ניתן להחליף חבר ועד במידה והוחלט על כך ברוב קולות." },
        { question: "איך ניתן לפנות לוועד הבית?", answer: "ניתן לפנות לוועד הבית דרך דואר אלקטרוני, טלפון או בתיבת הדואר המיועדת לכך בבניין." },
        { question: "מה קורה אם אין מתנדבים לוועד הבית?", answer: "במקרה כזה ניתן לשכור שירותי ניהול חיצוניים שיבצעו את תפקידי הוועד." },
        { question: "האם חובה להיות חבר ועד?", answer: "לא, החברות בוועד הבית היא על בסיס התנדבותי, אך כל דייר חייב לשלם את דמי הוועד." }
    ];

    return (
        <div className="faq-container">
            <h2>שאלות נפוצות</h2>
            <div className="faq-list">
                {faqs.map((faq, index) => (
                    <div key={index} className="faq-item">
                        <div className="faq-question" onClick={() => toggleAnswer(index)}>
                            {faq.question}
                        </div>
                        {activeIndex === index && (
                            <div className="faq-answer">
                                {faq.answer}
                            </div>
                        )}
                    </div>
                ))}
            </div>
        </div>
    );
};

export default FAQComponent;
