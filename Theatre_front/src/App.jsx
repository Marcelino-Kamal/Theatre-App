
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Home from "./Views/Home";
import Register from "./Views/Register";
import Login from "./Views/Login";

function App() {
  

  return (
    <div className="w-full flex h-screen bg-gray-500">
      <Router>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/login" element={<Login />} />
          <Route path="/signup" element={<Register />} />
        </Routes>
      </Router>
    </div>
  );
}

export default App;
