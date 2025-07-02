import { useEffect, useState } from "react";
import DashboardNav from "../components/DashboardComponents/DashboardNav";
import { fetchitems } from "../API/items";
import ICards from "../components/ICards";

export default function Dashboard() {
  const [items, setItems] = useState([]);
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(true); 

  const loaditems = async () => {
    try {
      const data = await fetchitems();
      setItems(data);
    } catch (err) {
      console.error(err);
      setError("Failed to load items. Please try again later.");
    } finally {
      setLoading(false); 
    }
  };

  useEffect(() => {
    loaditems();
  }, []);

  return (
    <div className="w-full max-h-full flex-col flex-wrap pt-24">
      <div className="w-full px-4">
        {loading ? (
          <p className="text-center text-gray-600">Loading...</p>
        ) : error ? (
          <p className="text-center text-red-500">{error}</p>
        ) : items.length === 0 ? (
          <p className="text-center text-gray-500">No items available.</p>
        ) : (
          <div className="grid lg:grid-cols-4 md:grid-cols-2 sm:grid-cols-2 gap-4">
            {items.map((item) => (
              <ICards key={item.id} data={item} />
            ))}
          </div>
        )}
      </div>
    </div>
  );
}
