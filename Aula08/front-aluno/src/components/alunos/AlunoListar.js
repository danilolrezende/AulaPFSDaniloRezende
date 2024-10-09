import axios from "axios";
import React from "react";
import { useState, useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";


const AlunoListar = () => {
    const [obj, setObj] = useState(null);
    const navigate = useNavigate();

    const carregarDados = () => {
        axios.get('http://localhost:3005/alunos').then(resp => {
            //console.log(resp.data);
            setObj(resp.data);
        })
    };

    useEffect(() => {
        carregarDados();
    }, []);

    const excluir = (e, id) => {
        e.preventDefault();
        axios.delete(`http://localhost:3005/alunos/${id}`)
           .then(resp => {
            navigate(0)
           });
    }

    if (!obj) {
        return <div>Carregando...</div>;
    }


    return (
        <div>
            <Link to={`/alunos/inserir`} className="btn btn-primary">Inserir</Link>
            <table className="table">
                <thead>
                    <tr>
                        <th>Matricula</th>
                        <th>Nome</th>
                    </tr>
                </thead>
                <tbody>
                    {obj.map((x) => (
                        <tr key={x.id}>
                            <td>{x.matricula}</td>
                            <td>{x.nome}</td>
                            <td>
                                <Link to={`/alunos/consultar/${x.id}`} className="btn btn-secondary">Consultar</Link>
                                <Link to={`/alunos/alterar/${x.id}`} className="btn btn-warning">Alterar</Link>
                                <button className="btn btn-danger" onClick={e => excluir(e, x.id)}>Excluir</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}

export default AlunoListar;