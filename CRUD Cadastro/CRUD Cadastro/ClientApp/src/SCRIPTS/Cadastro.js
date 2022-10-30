let login = document.querySelector("#usuarioField");
let senha = document.querySelector("#senhaField");
let reSenha = document.querySelector("#reSenhaField");
let nome = document.querySelector("#nomeField");
let cpf = document.querySelector("#cpfField");
let telefone = document.querySelector("#telField");
let cel = document.querySelector("#celField");
let endereco = document.querySelector("#enderecoField");
let cidade = document.querySelector("#cidadeField");
let estado = document.querySelector("#estadoField");
let cep = document.querySelector("#cepField");

const btnSignUp = document.querySelector("#btnSignUp");

btnSignUp.onclick = () => {
  handleSignUp();
};

function getCep() {
  fetch("https://viacep.com.br/ws/" + cep.value + "/json")
    .then((response) => response.json())
    .then((resp) => {
      endereco.value = resp.logradouro + " - " + resp.bairro;
      estado.value = resp.uf;
      cidade.value = resp.localidade;
    });
}

const handleSignUp = () => {
  axios({
    method: "post",
    url: "https://localhost:5001/PostPessoa",
    data: {
      cel: cel.value,
      cep: cep.value,
      cidade: cidade.value,
      cpf: cpf.value,
      endereco: endereco.value,
      nome: nome.value,
      login: login.value,
      senha: senha.value,
    },
  })
    .then(() => {
      alert("Usuario cadastrado com sucesso");
    })
    .catch((err) => alert(err));
};
