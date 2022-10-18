import { path } from "../Index.js";

const tbody = document.querySelector("tbody");

let itens;

function getPessoas() {
  console.log(path);
  fetch(path + "/api/Pessoa")
    .then((response) => {
      return response.json();
    })
    .then(function (data) {
      itens = data;
      loadItens();
    })
    .catch((err) => {
      console.log(err);
    });
}

function deleteItem(id) {
  if (!window.confirm("Você deseja realmente deletar este usuário?")) {
    return;
  }
  fetch("api/Pessoa/" + id, { method: "delete" }).then(() => {
    alert("Usuário deletado com Sucesso!");
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
    <td class="acao">
      <button onclick="deleteItem(${item.id})"><i class='bx bx-trash'></i></button>
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
