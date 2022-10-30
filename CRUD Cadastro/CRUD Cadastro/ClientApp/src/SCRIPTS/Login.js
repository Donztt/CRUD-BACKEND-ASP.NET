let login = document.querySelector("#loginField");
let senha = document.querySelector("#senhaField");

const loginButton = document.querySelector("#LoginButton");

loginButton.onclick = () => {
  AuthLogin();
};

const AuthLogin = () => {
  axios({
    method: "get",
    url: "https://localhost:5001/AuthLogin",
    data: {
      login: login.value,
      senha: senha.value,
    },
  })
    .then((resp) => {
      alert(resp);
    })
    .catch(() => alert("Usuário ou senha inválido"));
};
