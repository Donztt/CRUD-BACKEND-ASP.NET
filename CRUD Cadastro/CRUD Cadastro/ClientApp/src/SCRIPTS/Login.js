class Login {
  constructor() {
    super();
    this.intialize();
    this.HandleLogin = this.HandleLogin.bind(this);
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

  async HandleLogin(event) {
    event.preventDefault();

    const response = await fetch(
      "api/Login/Login/" + this.state.login + "," + this.state.password
    );
    const data = await response.json();

    if (data.title == "Bad Request") {
      alert("senha ou usuário incorreto");
    } else {
      this.props.history.push("/dadosUsuario/" + data.pessoa_id);
    }
  }
}
