import React, { useEffect, useState } from "react";
import {
    getInventories,
    createInventory,
    updateInventory,
    deleteInventory,
} from "../../services/inventoryAPI"

import {
    getCurrentUser
} from "../../services/userAPI"

import './Inventory.css'
function Inventory() {
    const [inventories, setInventories] = useState([]);
    const [name, setName] = useState("");
    const [description, setDescription] = useState("");
    const [color, setColor] = useState("");
    const [suppliers, setSuppliers] = useState("");
    const [manufacturers, setManufacturers] = useState("");
    const [editing, setEditing] = useState(null);
    const [userInfor, setUserLogin] = useState("");

    const load = async () => {
        const data = await getInventories();
        setInventories(data);

        const user = await getCurrentUser();
        console.log(user);
        setUserLogin(user);
    };

    useEffect(() => {
        load();
    }, []);

    const handleSubmit = async (e) => {
        e.preventDefault();
        if (!name.trim()) return;

        const inventory = { name, description, color, suppliers, manufacturers };

        if (editing) {
            await updateInventory({ ...inventory, id: editing.id });
            setEditing(null);
        } else {
            await createInventory(inventory);
        }
        setName("");
        setDescription("");
        setColor("");
        setSuppliers("");
        setManufacturers("");
        await load();
    };

    const handleEdit = (i) => {
        setEditing(i);
        setName(i.name);
        setDescription(i.description);
        setColor(i.color);
        setSuppliers(i.suppliers);
        setManufacturers(i.manufacturers);
    };

    const handleDelete = async (id) => {
        await deleteInventory(id);
        await load();
    };

    return (
        <div style={{ padding: "2rem" }}>

            <nav>
                {userInfor ? (
                    <div>
                        <span>Welcome, {userInfor.name} in the role of <strong>{userInfor.claims[1].value}</strong> 👋</span>
                        <a href="/login">Logout</a>
                    </div>
                ) : (
                    <a href="/login">Login</a>
                )}
            </nav>
            <h2>Inventory Management</h2>

            <form onSubmit={handleSubmit}>
                <div>
                    <input
                        placeholder="Inventory Name"
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                    />
                </div>
                <div>
                    <input
                        placeholder="Description"
                        value={description}
                        onChange={(e) => setDescription(e.target.value)}
                    />
                </div>
                <div>
                    <input
                        placeholder="Color"
                        value={color}
                        onChange={(e) => setColor(e.target.value)}
                    />
                </div>
                <div>
                    <input
                        placeholder="Suppliers"
                        value={suppliers}
                        onChange={(e) => setSuppliers(e.target.value)}
                    />
                </div>
                <div>
                    <input
                        placeholder="Manufacturers"
                        value={manufacturers}
                        onChange={(e) => setManufacturers(e.target.value)}
                    />
                </div>
                <button type="submit">{editing ? "Update" : "Add"}</button>
            </form>
            <table>
                <thead>
                    <tr>
                        <th>Inventory Name</th>
                        <th>Description</th>
                        <th>Color</th>
                        <th>Suppliers</th>
                        <th>Manufacturers</th>
                    </tr>
                </thead>
                <tbody>
                    {inventories.map((i) => (
                        <tr key={i.id}>
                            <td>{i.name}</td>
                            <td>{i.description}</td>
                            <td>{i.color}</td>
                            <td>{i.suppliers}</td>
                            <td>{i.manufacturers}</td>
                            <td><button onClick={() => handleEdit(i)}>Edit</button></td>
                            <td><button onClick={() => handleDelete(i.id)}>Delete</button></td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}

export default Inventory;