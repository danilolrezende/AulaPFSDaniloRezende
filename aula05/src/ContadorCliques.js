import React, { useContext } from "react";
import { CliqueContext } from "./App";

/* const ContadorCliques = ({ cliques, setCliques }) => { */
const ContadorCliques = () => {
    const [cliques, setCliques] = useContext(CliqueContext)
    return (
        <div>
            <button onClick={() => setCliques(cliques + 1)}>Clique aqui</button>
            <label>{cliques} cliques efetuados...</label>
        </div>
    );
};

export default ContadorCliques;