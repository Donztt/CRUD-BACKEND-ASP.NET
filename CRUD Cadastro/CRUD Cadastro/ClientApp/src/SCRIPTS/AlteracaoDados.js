class AlteracaoDados {
  static displayName = "Pessoas";

  constructor() {
    super();
    this.state = { pessoa: [] };
    this.handleEdit = this.handleEdit.bind(this);
  }

  componentDidMount() {
    this.ChargePeople();
  }

  async ChargePeople() {
    var id = this.props.match.params["id"];
    const response = await fetch("api/Pessoa/" + id);
    const dataz = await response.json();
    this.setState({ pessoa: dataz });
  }

  render() {
    let editScreenv = this.editScreen();

    return <div>{editScreenv}</div>;
  }

  handleEdit(event) {
    if (!window.confirm("Você deseja realmente alterar os dados?")) {
      return;
    }
    event.preventDefault();
    const data = new FormData(event.target);

    fetch("api/Pessoa/" + this.state.pessoa.id, { method: "PUT", body: data });
    window.location.href = "/";
  }
}

function HandleDeleteItem(id) {
  if (!window.confirm("Você deseja realmente deletar este usuário?")) {
    return;
  }
  fetch("api/Pessoa/" + id, { method: "delete" }).then((json) => {
    fetch("api/Login/" + id, { method: "delete" });
  });
  window.location.href = "/";
  alert("Usuário deletado com Sucesso!");
}
