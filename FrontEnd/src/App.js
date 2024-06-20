// import { BrowserRouter, Route, Routes } from "react-router-dom";
// import Connection from "./Components/connection.component";
// import PersonalArea from './Components/personalArea.component';
// import Home from './Components/home.component';
// import Register from './Components/register.component';

// function App() {
//   return (
//     <BrowserRouter>
//       <Routes>
//         <Route path="/" element={<Home />} />
//         <Route path="/home" element={<Home />} />
//         <Route path="/register" element={<Register />} />
//         <Route path="/connection" element={<Connection />} />
//         <Route path="/personal-area" element={<PersonalArea />} />
//       </Routes>
//     </BrowserRouter>
//   );
// }

// export default App;

import { BrowserRouter, Route, Routes } from "react-router-dom";
import Connection from "./Components/connection.component";
import PersonalArea from './Components/personalArea.component';
import Home from './Components/home.component';
import Register from './Components/register.component';
import Navbar from './Components/navbar.component';
import About from './Components/about.component';
import FAQ from './Components/faq.component';
import Contact from './Components/contact.component';

function App() {
  return (
    <BrowserRouter>
      <div>
        <Navbar />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/home" element={<Home />} />
          <Route path="/register" element={<Register />} />
          <Route path="/connection" element={<Connection />} />
          <Route path="/personal-area" element={<PersonalArea />} />
          <Route path="/about" element={<About />} />
          <Route path="/faq" element={<FAQ />} />
          <Route path="/contact" element={<Contact />} />
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
