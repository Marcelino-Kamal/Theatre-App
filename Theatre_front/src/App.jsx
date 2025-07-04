import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Home from "./Views/Home";
import Register from "./Views/AuthView/Register";
import Login from "./Views/AuthView/Login";
import Dashboard from "./Views/UserDashboard/Dashboard";
import ItemPage from "./Views/ItemView/ItemPage";
import DashboardLayout from "./Views/Shared/_DashboardLayout";
import Profile from "./Views/UserDashboard/Profile";
import CartProvider from "./context/CartContext";
import Checkout from "./Views/CheckoutView/Checkout";
import AdminLayout from "./Views/Shared/_AdminLayout";
import AdminDash from "./Views/AdminDashboard/AdminDash";
import AdminProfile from "./Views/AdminDashboard/AdminProfile";
import RequireRole from "./config/RequireRole";
import ManagerDash from "./Views/AdminDashboard/ManagerDash";
import ItemList from "./Views/AdminDashboard/Lists/ItemList";
import OrderList from "./Views/AdminDashboard/Lists/OrderList"
import UserList from "./Views/AdminDashboard/Lists/UserList";
import AddItem from "./Views/AdminDashboard/AddingForms/AddItem";

function App() {
  return (
    <div className="w-full flex h-screen bg-[#D9D9D9]">
      <Router>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/login" element={<Login />} />
          <Route path="/signup" element={<Register />} />

          <Route
            element={
              <RequireRole role="admin">
                <AdminLayout />
              </RequireRole>
            }
          >
            <Route path="/admin" element={<AdminDash />} />
            <Route path="/adminprofile" element={<AdminProfile />} />
            <Route path="/manager" element={<ManagerDash />} />
            <Route path="/productlist" element={<ItemList />} />
            <Route path="/orderlist" element={<OrderList />} />
            <Route path="/userlist" element={<UserList />} />
            <Route path="/additem" element={<AddItem/>}/>
          </Route>
          <Route
            element={
              <CartProvider>
                <DashboardLayout />
              </CartProvider>
            }
          >
            <Route path="/dashboard" element={<Dashboard />} />
            <Route path="/iteminfo/:id" element={<ItemPage />} />
            <Route path="/profile" element={<Profile />} />
            <Route path="/checkout" element={<Checkout />} />
          </Route>
        </Routes>
      </Router>
    </div>
  );
}

export default App;
