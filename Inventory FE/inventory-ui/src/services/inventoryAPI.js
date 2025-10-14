const API_URL = "https://localhost:7269/api/inventories";
const token = localStorage.getItem("token");


export async function getInventories() {
    const res = await fetch(API_URL, {
        headers: { "Authorization": `Bearer ${token}`},
    });
    return res.json();
}

export async function createInventory(inventory) {
    await fetch(API_URL, {
        method: "POST",
        headers: { "Content-Type": "application/json", "Authorization": `Bearer ${token}` },
        body: JSON.stringify(inventory)
    });
}

export async function updateInventory(inventory) {
    await fetch(`${API_URL}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json", "Authorization": `Bearer ${token}` },
        body: JSON.stringify(inventory)
    });
}

export async function deleteInventory(id) {
    await fetch(`${API_URL}/${id}`, {
        method: "DELETE",
        headers: { "Authorization": `Bearer ${token}` }
    });
}