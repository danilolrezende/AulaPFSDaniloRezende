import axios from "axios";
import React, { useState } from "react";
import { useNavigate, useParams } from "react-router-dom";


const AlunoInserir = () => {
    const [obj, setObj] = useState([
        {  matricula: 0, nome: "" }
    ]);

    const navigate = useNavigate();

    const salvar = e => {
        e.preventDefault();
        axios.post(`http://localhost:3005/alunos`, obj).then(resp => {
            navigate(`/alunos`);
        })
    };

    const voltar = (e) => {
        e.preventDefault();
        navigate("/alunos");
    }

    const atualizarCampo = (nome, valor) => {
        setObj({...obj, [nome]: valor });
    };

    return (
        <form>
            <div>
                <label className="form-label">Matrícula</label>
                <input className="form-control" type="text" 
                onChange={e => atualizarCampo('matricula', e.target.value)} value={obj.matricula} />
            </div>
            <div>
                <label className="form-label">Nome</label>
                <input className="form-control" type="text" 
                onChange={e => atualizarCampo('nome', e.target.value)} value={obj.nome}/>
            </div>
            <button className="btn btn-primary mt-2" onClick={e => salvar(e)}>Salvar</button>
            <button className="btn btn-secondary mt-2" onClick={e => voltar(e)}>Voltar</button>
        </form>
    );  
}

export default AlunoInserir;