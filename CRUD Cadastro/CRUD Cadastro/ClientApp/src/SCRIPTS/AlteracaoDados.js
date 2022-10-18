import { path } from "../Index.js";

let id = document.querySelector("#idField");
let nome = document.querySelector("#nomeField");
let cpf = document.querySelector("#cpfField");
let telefone = document.querySelector("#telField");
let cel = document.querySelector("#celField");
let endereco = document.querySelector("#enderecoField");
let cidade = document.querySelector("#cidadeField");
let estado = document.querySelector("#estadoField");

const btnEdit = document.querySelector("#btnEdit");
const btnDelete = document.querySelector("#btnDelete");

let dataz;

const params = new URLSearchParams(window.location.search).get("id");

btnEdit.onclick = () => {
  editItem();
};

btnDelete.onclick = () => {
  deleteItem();
};
const chargePeople = () => {
  var id = params;
  fetch(path + "/api/Pessoa/" + id)
    .then((response) => {
      return response.json();
    })
    .then(function (data) {
      dataz = data;
      id = data.id;
      nome.value = data.nome;
      cpf.value = data.cpf;
      cel.value = data.cel;
      endereco.value = data.endereco;
      cidade.value = data.cidade;
      estado.value = data.estado;
    });
};

const editItem = () => {
  if (!window.confirm("Você deseja realmente alterar os dados?")) {
    return;
  }
  const bodyEdit = {
    Id: dataz.id,
    Nome: dataz.nome,
    Cel: dataz.cel,
    Cidade: dataz.cidade,
    CPF: dataz.cpf,
    Endereco: dataz.endereco,
    Estado: dataz.estado,
  };

  var data = new FormData();
  data.append("json", JSON.stringify(bodyEdit));

  fetch(path + "/api/Pessoa/update", {
    method: "POST",
    body: data,
  }).then(() => {
    alert("Usuário editado com Sucesso!");
  });
};

function deleteItem() {
  if (!window.confirm("Você deseja realmente deletar este usuário?")) {
    return;
  }
  fetch("api/Pessoa/delete/" + dataz.id, { method: "POST" }).then(() => {
    alert("Usuário deletado com Sucesso!");
  });
}

chargePeople();
