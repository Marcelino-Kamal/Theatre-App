import DashboardNav from "../../components/DashboardComponents/DashboardNav";
import { Outlet } from "react-router-dom";
export default function DashboardLayout() {
  return (
    <div className="w-full flex flex-col">
      <DashboardNav />
      <main >
        <Outlet />
      </main>
    </div>
  );
}
