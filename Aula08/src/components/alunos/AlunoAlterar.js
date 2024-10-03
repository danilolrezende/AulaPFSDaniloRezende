import React, { useState } from "react";
import { useParams } from "react-router-dom";

const AlunoAlterar = () => {
    const [obj, setObj] = useState([
        { id: "3", matricula: 789, nome: "Maria" }
    ]);
    const { id } = useParams();

    if (obj == null) {
        return <div>Carregando...</div>;
    }

    return (
        <form>
            <div>
                <label className="form-label">Matrícula</label>
                <input className="form-control" type="text" value={obj.matricula} />
            </div>
            <div>
                <label className="form-label">Nome</label>
                <input className="form-control" type="text" value={obj.nome}/>
            </div>
            <button className="btn btn-secondary mt-2">Voltar</button>
        </form>
    );      
}

export default AlunoAlterar;