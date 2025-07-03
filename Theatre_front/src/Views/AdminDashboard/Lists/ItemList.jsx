import React, { useEffect, useRef, useState } from "react";
import { fetchitems } from "../../../API/items";
import $ from "jquery";
import "datatables.net";

export default function ProductTable() {
  const tableRef = useRef();
  const [items, setItems] = useState([]);
  const [loading, setLoading] = useState(true);
  const dataTable = useRef(null);

  useEffect(() => {
    const loadItems = async () => {
      try {
        const data = await fetchitems();
        setItems(data);
      } catch (error) {
        console.error("Error loading items:", error.message);
      } finally {
        setLoading(false);
      }
    };

    loadItems();
  }, []);

  useEffect(() => {
    if (!loading && items.length > 0) {
      dataTable.current = $(tableRef.current).DataTable();
    }

    return () => {
      if (dataTable.current) {
        dataTable.current.destroy();
        dataTable.current = null;
      }
    };
  }, [loading, items]);

  return (
    <div className="p-6 min-h-screen bg-[#D2B48C]">
      <h2 className="text-2xl font-bold mb-6 mt-14">All Products</h2>

      {loading ? (
        <p>Loading...</p>
      ) : (
        <div className="overflow-x-auto bg-white rounded-xl shadow-lg p-4">
          <table
            ref={tableRef}
            className="display w-full border border-gray-300 text-sm text-left"
          >
            <thead className="bg-gray-100">
              <tr>
                <th className="border px-4 py-2">Id</th>
                <th className="border px-4 py-2">Name</th>
                <th className="border px-4 py-2">Description</th>
                <th className="border px-4 py-2">Price</th>
                <th className="border px-4 py-2">Quantity</th>
                <th className="border px-4 py-2">Catalogue</th>
                <th className="border px-4 py-2">Image</th>
              </tr>
            </thead>
            <tbody>
              {items.map((item) => (
                <tr key={item.id} className="hover:bg-gray-50 transition">
                  <td className="border px-4 py-2">{item.id}</td>
                  <td className="border px-4 py-2">{item.name}</td>
                  <td className="border px-4 py-2">{item.description}</td>
                  <td className="border px-4 py-2">{item.price}</td>
                  <td className="border px-4 py-2">{item.quantity}</td>
                  <td className="border px-4 py-2">{item.catalogue}</td>
                  <td className="border px-4 py-2">
                    <img
                      src={`${
                        import.meta.env.VITE_API_BASE_URL
                      }${item.imgUrl.replace(/\\/g, "/")}`}
                      alt={item.name}
                      className="h-16 w-16 object-cover rounded"
                    />
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      )}
    </div>
  );
}
