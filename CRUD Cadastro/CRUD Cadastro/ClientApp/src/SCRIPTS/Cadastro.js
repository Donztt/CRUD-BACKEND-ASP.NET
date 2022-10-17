class Cadastro {
  static displayName = "Pessoas";

  constructor(props) {
    super(props);
    this.intialize();

    this.HandleSignUp = this.HandleSignUp.bind(this);
    this.handleLoginChange = this.handleLoginChange.bind(this);
    this.handlePasswordChange = this.handlePasswordChange.bind(this);
  }

  async intialize() {
    this.state = { login: "" };
    this.state = { password: "" };
  }

  handleLoginChange(e) {
    this.setState({ login: e.target.value });
  }
  handlePasswordChange(e) {
    this.setState({ password: e.target.value });
  }

  HandleSignUp(event) {
    event.preventDefault();

    const datax = new FormData(event.target);

    fetch("api/Pessoa/", { method: "POST", body: datax })
      .then((response) => response.json())
      .then((data) => {
        const login = new FormData();

        login.append("Login[Id]", 0);
        login.append("Login[LoginNome]", this.state.login);
        login.append("Login[Senha]", this.state.password);
        login.append("Login[Pessoa_id]", data.id);

        fetch("api/Login/", { method: "POST", body: login });
      });

    this.props.history.push("/");
  }
}
