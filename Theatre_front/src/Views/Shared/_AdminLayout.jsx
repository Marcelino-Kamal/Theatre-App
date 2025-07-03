import AdminNavbar from "../../components/AdminDashboardComponets/AdminNavbar";
import { Outlet } from "react-router-dom";

export default function AdminLayout (){

    return(
        <div className="w-full flex flex-col">
            <AdminNavbar/>
                <main>
                    <Outlet />
                </main>
        </div>
    );
    
};

