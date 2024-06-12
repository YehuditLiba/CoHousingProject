import { BrowserRouter, Route, Routes } from "react-router-dom";
import Connection from "./Components/connection.component";
import PersonalAreaComponent from './Components/personalArea.component';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Connection />} />
        <Route path="/personal-area" element={<PersonalAreaComponent />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
