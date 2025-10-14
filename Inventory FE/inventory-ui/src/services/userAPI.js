const API_URL = "https://localhost:7269/api/users";
const token = localStorage.getItem("token");

export async function getCurrentUser() {
    const res = await fetch(API_URL + "/me", {
        headers: { "Authorization": `Bearer ${token}`},
    });

    return res.json();
}