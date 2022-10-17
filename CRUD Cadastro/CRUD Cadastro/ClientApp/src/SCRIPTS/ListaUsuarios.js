const tbody = document.querySelector("tbody");

let itens;

function getPessoas() {
  fetch("https://localhost:5001/api/Pessoa")
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

function handleChangeUser(id) {
  window.location.href = "/AlteracaoDeDados/" + id;
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
      <button onclick="editItem(${index})"><i class='bx bx-edit' ></i></button>
    </td>
    <td class="acao">
      <button onclick="deleteItem(${index})"><i class='bx bx-trash'></i></button>
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
