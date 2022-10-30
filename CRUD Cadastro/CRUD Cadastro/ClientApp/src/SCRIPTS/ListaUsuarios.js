import { path } from "../Index.js";

const tbody = document.querySelector("tbody");

let itens;

function getPessoas() {
  axios({
    method: "get",
    url: path + "/pessoas",
  })
    .then((pessoas) => {
      itens = pessoas.data;
      loadItens();
    })
    .catch((err) => {
      alert(err);
    });
}

function deleteItem(id) {
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

function insertItem(item, index) {
  let tr = document.createElement("tr");
  tr.innerHTML = `
    <td>${item.nome}</td>
    <td>${item.cpf}</td>
    <td>${item.cidade}</td>
    <td>${item.estado}</td>
    <td>${item.endereco}</td>
    <td>${item.cel}</td>
    <td class="acao">
      <button onclick="location.href='./AlteracaoDados.html?id=${item.id}'"><i class='bx bx-edit' ></i></button>
    </td>
  `;
  tbody.appendChild(tr);
}

function loadItens() {
  tbody.innerHTML = "";
  itens.forEach((item, index) => {
    insertItem(item, index);
  });
}
getPessoas();
