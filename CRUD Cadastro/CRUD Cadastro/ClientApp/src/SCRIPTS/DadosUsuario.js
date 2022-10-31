let nome = document.querySelector("#nomeField");
let cpf = document.querySelector("#cpfField");
let cel = document.querySelector("#celField");
let endereco = document.querySelector("#enderecoField");
let cidade = document.querySelector("#cidadeField");
let estado = document.querySelector("#estadoField");
let cep = document.querySelector("#cepField");
let titleNome = document.querySelector("#titleNomeField");

const pessoaid = new URLSearchParams(window.location.search).get("id");

const chargePeople = () => {
  axios({
    method: "get",
    url: "https://localhost:5001/getPessoa/" + pessoaid,
  })
    .then((resp) => {
      console.log(resp.data);
      nome.innerHTML = resp.data.nome;
      cpf.innerHTML = resp.data.cpf;
      cel.innerHTML = resp.data.cel;
      endereco.innerHTML = resp.data.endereco;
      cidade.innerHTML = resp.data.cidade;
      estado.innerHTML = resp.data.estado;
      cep.innerHTML = resp.data.cep;
      titleNome.innerHTML = "Olá, " + resp.data.nome;
    })
    .catch(() => alert("Usuário ou senha inválido"));
};

chargePeople();
