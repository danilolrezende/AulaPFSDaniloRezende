import React from 'react';
import axios from 'axios';

const listar = () => {
  axios.get('http://localhost:3005/alunos').then(
    resultado => {
      console.log(resultado.data);

    }
  )
}

const consultarUnico = id => {
  axios.get(`http://localhost:3005/alunos/${id}`).then(
    resultado => {
      console.log(resultado.data);
    }
  )
}

const excluir = id => {
  axios.delete(`http://localhost:3005/alunos/${id}`).then(
    resultado => {
      console.log(resultado.status);
    }
  )
}

const inserir = () => {
  const aluno = { id: "999", matricula: 999, nome: 'Aluno Teste' }
  axios.post('http://localhost:3005/alunos', aluno).then(
    resultado => {
      console.log(resultado.status);
    }
  )
}


const alterar = id => {
  axios.get(`http://localhost:3005/alunos/${id}`).then(
    resultado => {
      let aluno = resultado.data;
      aluno.nome += ' Alterado';
      axios.put(`http://localhost:3005/alunos/${id}`, aluno).then(
        resultado => {
          console.log(resultado.status);
        }
      )
    }
  )

}

function App() {
  return (
    <div>
      <button onClick={listar}>Lista</button>
      <button onClick={() => consultarUnico(1)}>Consultar Único</button>
      <button onClick={inserir}>Inserir</button>
      <button onClick={() => alterar(999)}>Alterar</button>
      <button onClick={() => excluir(4)}>Excluir</button>
    </div>
  );
}

export default App;
