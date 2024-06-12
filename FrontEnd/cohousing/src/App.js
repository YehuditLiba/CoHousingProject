
import { Component } from 'react';
import './App.css';
import {BrowserRouter,Route,Routes} from "react-router-dom"
import Connection from "./Componet/connection"




function App() {
  return (
    <BrowserRouter>
    <Routes>
      <Route path="/" element={<Connection/>}/>
        <Route/>
    </Routes>
    </BrowserRouter>
  );
}

export default App;
