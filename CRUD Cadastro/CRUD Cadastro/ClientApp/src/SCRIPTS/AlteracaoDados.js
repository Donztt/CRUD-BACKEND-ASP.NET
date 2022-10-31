import { path } from "../Index.js";

let id;
let nome = document.querySelector("#nomeField");
let cpf = document.querySelector("#cpfField");
let telefone = document.querySelector("#telField");
let endereco = document.querySelector("#enderecoField");
let cidade = document.querySelector("#cidadeField");
let estado = document.querySelector("#estadoField");
let cep = document.querySelector("#cepField");

const btnEdit = document.querySelector("#btnEdit");
const btnDelete = document.querySelector("#btnDelete");

let dataz;

const pessoaid = new URLSearchParams(window.location.search).get("id");

btnEdit.onclick = () => {
  editItem();
};

btnDelete.onclick = () => {
  deleteItem();
};
const chargePeople = () => {
  axios({
    method: "get",
    url: path + "/Pessoa/" + pessoaid,
  }).then((pessoa) => {
    id = pessoa.data.id;
    nome.value = pessoa.data.nome;
    cpf.value = pessoa.data.cpf;
    endereco.value = pessoa.data.endereco;
    cidade.value = pessoa.data.cidade;
    estado.value = pessoa.data.estado;
    cep.value = pessoa.data.cep;
    telefone.value = pessoa.data.cel;
  });
};

const editItem = () => {
  if (!window.confirm("Você deseja realmente alterar os dados?")) {
    return;
  }
  axios({
    method: "post",
    url: path + "/updatePessoa",
    data: {
      id: id,
      nome: nome.value,
      cep: cep.value,
      cpf: cpf.value,
      cidade: cidade.value,
      estado: estado.value,
      endereco: endereco.value,
      cel: telefone.value,
    },
  }).then(() => {
    alert("usuário alterado com sucesso");
    window.location.replace("/src/HTML/ListaUsuario.html");
  });
};

function deleteItem() {
  if (!window.confirm("Você deseja realmente deletar este usuário?")) {
    return;
  }

  axios({
    method: "post",
    url: path + "/deletePessoa/" + id,
  }).then(() => {
    alert("Usuário deletado com Sucesso!");
    window.location.replace("/src/HTML/ListaUsuario.html");
  });
}

chargePeople();
