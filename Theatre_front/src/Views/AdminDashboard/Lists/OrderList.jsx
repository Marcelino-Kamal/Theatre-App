import React, { useEffect, useRef, useState } from "react";
import { getOrders,updateOrderStatus } from "../../../API/Orders";
import $ from "jquery";
import { format } from "date-fns";
import "datatables.net";

export default function OrderTable() {
  const tableRef = useRef();
  const [orders, setOrders] = useState([]);
  const [loading, setLoading] = useState(true);
  const dataTable = useRef(null);

  useEffect(() => {
    const loadOrders = async () => {
      try {
        const data = await getOrders();
        setOrders(
          data.map((order) => ({
            ...order,
            isApproved: !!order.isApproved,
            isPaid: !!order.isPaid,
          }))
        );
      } catch (error) {
        console.error("Error loading Orders:", error.message);
      } finally {
        setLoading(false);
      }
    };

    loadOrders();
  }, []);

  const handleCheckboxChange = (orderId, field) => {
    setOrders((prev) =>
      prev.map((order) =>
        order.orderId === orderId ? { ...order, [field]: !order[field] } : order
      )
    );
  };
  const handleSave = async (order) => {
    try {
      const payload = {
        orderId: order.orderId,
        isApproved: order.isApproved,
        isPaid: order.isPaid,
      };

      
      await updateOrderStatus(payload);

      alert("Order updated!");
    } catch (err) {
      console.error("Failed to update order", err.message);
      alert("Failed to update order.");
    }
  };

  useEffect(() => {
  if (!loading && orders.length > 0 && !dataTable.current) {
    dataTable.current = $(tableRef.current).DataTable({
      stateSave: true 
    });
  }
}, [loading]); 


  return (
    <div className="p-6 min-h-screen bg-[#D2B48C]">
      <h2 className="text-2xl font-bold mb-6 mt-14">All Orders</h2>

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
                <th className="border px-4 py-2">Order Id</th>
                <th className="border px-4 py-2">User Name</th>
                <th className="border px-4 py-2">Item Name</th>
                <th className="border px-4 py-2">Quantity</th>
                <th className="border px-4 py-2">Is Approved</th>
                <th className="border px-4 py-2">is Paid</th>
                <th className="border px-4 py-2">Start Date</th>
                <th className="border px-4 py-2">End Date</th>
                <th className="border px-4 py-2">Abona approved image</th>
                <th className="border px-4 py-2">payment image</th>
                <th className="border px-4 py-2"></th>
              </tr>
            </thead>
            <tbody>
              {orders.map((order) => (
                <tr
                  key={`${order.orderId}-${order.itemName}`}
                  className="hover:bg-gray-50 transition"
                >
                  <td className="border px-4 py-2">{order.orderId}</td>
                  <td className="border px-4 py-2">{order.userName}</td>
                  <td className="border px-4 py-2">{order.itemName}</td>
                  <td className="border px-4 py-2">{order.count}</td>
                  <td className="border px-4 py-2">
                    <input type="checkbox" checked={order.isApproved} onChange={() => handleCheckboxChange(order.orderId, "isApproved")} />
                  </td>
                  <td className="border px-4 py-2">
                    <input type="checkbox" checked={order.isPaid}  onChange={() => handleCheckboxChange(order.orderId, "isPaid")} />
                  </td>
                  <td className="border px-4 py-2">
                    {format(new Date(order.startDate), "dd-MM-yyyy")}
                  </td>
                  <td className="border px-4 py-2">
                    {format(new Date(order.endDate), "dd-MM-yyyy")}
                  </td>
                  <td className="border px-4 py-2">{order.abona_Approved}</td>
                  <td className="border px-4 py-2">{order.payment}</td>
                  <td className="border px-4 py-2">
                    <button
                      onClick={() => handleSave(order)}
                      className="bg-[#D2B48C] text-white px-3 py-1 rounded hover:bg-[#DA6868]"
                    >
                      Edit
                    </button>
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
