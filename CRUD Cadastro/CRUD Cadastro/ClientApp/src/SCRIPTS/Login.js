let login = document.querySelector("#loginField");
let senha = document.querySelector("#senhaField");

const loginButton = document.querySelector("#LoginButton");

loginButton.onclick = () => {
  AuthLogin();
};

const AuthLogin = () => {
  axios({
    method: "post",
    url: "https://localhost:5001/AuthLogin",
    data: {
      login: login.value,
      senha: senha.value,
    },
  })
    .then((resp) => {
      console.log(resp.data);
      window.location.replace(
        "/src/HTML/DadosUsuario.html?id=" + resp.data.pessoa_id
      );
    })
    .catch(() => alert("Usuário ou senha inválido"));
};
