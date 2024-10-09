import axios from "axios";
import React, { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";

const AlunoAlterar = () => {
    const [obj, setObj] = useState([
        { id: "3", matricula: 789, nome: "Maria" }
    ]);
    const { id } = useParams();
    const navigate = useNavigate();

    useEffect(() => {
        axios.get(`http://localhost:3005/alunos/${id}`).then(resp => {
            setObj(resp.data)
        })
    }, []);

    const salvar = (e) => {
        e.preventDefault();
        axios.put(`http://localhost:3005/alunos/${id}`, obj).then(resp => {
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

    if (obj == null) {
        return <div>Carregando...</div>;
    }

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

export default AlunoAlterar;