import { BrowserRouter, Route, Routes } from "react-router-dom";
import Connection from "./Components/connection.component";
import PersonalArea from './Components/personalArea.component';
import Home from './Components/home.component';
import Register from './Components/register.component';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/home" element={<Home />} />
        <Route path="/register" element={<Register />} />
        <Route path="/connection" element={<Connection />} />
        <Route path="/personal-area" element={<PersonalArea />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
