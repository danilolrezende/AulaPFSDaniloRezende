import React from "react";
import { useState } from "react";


const AlunoListar = () => {
    const [obj, setObj] = useState([
        { id: "1", matricula: 123, nome: "Ana" },
        { id: "2", matricula: 456, nome: "Pedro" },
        { id: "3", matricula: 789, nome: "Maria" }
    ]);

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
                                <button className="btn btn-danger">Excluir</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}

export default AlunoListar;