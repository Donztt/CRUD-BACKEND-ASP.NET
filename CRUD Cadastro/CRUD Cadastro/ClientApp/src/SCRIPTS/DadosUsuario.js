class DadosUsuario {
  constructor() {
    super();
    this.state = { pessoa: [] };
  }

  componentDidMount() {
    this.ChargePeople();
  }

  async ChargePeople() {
    var id = this.props.match.params["id"];
    const response = await fetch("api/Pessoa/" + id);
    const data = await response.json();
    this.setState({ pessoa: data });
  }
}
