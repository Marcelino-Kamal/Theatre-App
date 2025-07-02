import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Home from "./Views/Home";
import Register from "./Views/AuthView/Register";
import Login from "./Views/AuthView/Login";
import Dashboard from "./Views/Dashboard";
import ItemPage from "./Views/ItemView/ItemPage";
import DashboardLayout from "./Views/Shared/_DashboardLayout";

function App() {
  return (
    <div className="w-full flex h-screen bg-[#D9D9D9]">
      <Router>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/login" element={<Login />} />
          <Route path="/signup" element={<Register />} />
          <Route element={<DashboardLayout/>}>
            <Route path="/dashboard" element={<Dashboard />} />
            <Route path="/iteminfo/:id" element={<ItemPage />} />
          </Route>
        </Routes>
      </Router>
    </div>
  );
}

export default App;
