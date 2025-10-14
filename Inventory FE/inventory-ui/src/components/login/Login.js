import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import './Login.css';
export default function Login() {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [message, setMessage] = useState("");
    const navigate = useNavigate();

    const handleLogin = async (e) => {
        e.preventDefault();

        try {
            const response = await fetch("https://localhost:7269/api/Users", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({ username, password }),
            });

            if (!response.ok) {
                const err = await response.json();
                setMessage(err.message || "Login failed");
                return;
            }

            const data = await response.json();
            localStorage.setItem("token", data.token);
            setMessage("Login successful!");

            navigate("/dashboard");

        } catch (error) {
            setMessage(error);
            console.error(error);
        }
    };

    return (
        <div style={{ maxWidth: 300, margin: "auto" }}>
            <h2>Login</h2>
            <form onSubmit={handleLogin}>
                <input
                    type="text"
                    placeholder="Username"
                    value={username}
                    onChange={(e) => setUsername(e.target.value)}
                    required
                /><br /><br />
                <input
                    type="password"
                    placeholder="Password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    required
                /><br /><br />
                <button type="submit">Login</button>
            </form>
            <p>{message}</p>
        </div>
    );
}