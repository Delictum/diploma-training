unit Unit8;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Data.FMTBcd, Datasnap.DBClient,
  Datasnap.Provider, Data.DB, Data.SqlExpr, Vcl.StdCtrls, Vcl.DBCtrls, Vcl.Mask;

type
  TForm8 = class(TForm)
    Button1: TButton;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    SQLQuery1: TSQLQuery;
    DataSource1: TDataSource;
    DataSetProvider1: TDataSetProvider;
    ClientDataSet1: TClientDataSet;
    DataSource2: TDataSource;
    ClientDataSet2: TClientDataSet;
    DataSetProvider2: TDataSetProvider;
    SQLQuery2: TSQLQuery;
    SQLQuery3: TSQLQuery;
    DataSetProvider3: TDataSetProvider;
    ClientDataSet3: TClientDataSet;
    DataSource3: TDataSource;
    Label4: TLabel;
    EditNebesTela: TDBEdit;
    Memo1: TDBMemo;
    TypeNebesTela: TDBComboBox;
    Golak: TDBComboBox;
    DBLCBTypeNebesTela: TDBLookupComboBox;
    DBLCBGolak: TDBLookupComboBox;
    Button2: TButton;
    DBEdit1: TDBEdit;
    DBEdit2: TDBEdit;
    DBEdit3: TDBEdit;
    Button3: TButton;
    Button4: TButton;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form8: TForm8;

implementation

{$R *.dfm}

uses Unit1, Unit9;

procedure TForm8.Button1Click(Sender: TObject);
Var BuftypenebestelaStr, BufHNebessvazStr, BufGolakStr : string;
    BufnebessvazID, i : integer;
begin
      ClientDataSet1.Active := false;
      SQLQuery1.Close;
      SQLQuery1.SQL.Clear;
      SQLQuery1.SQL.Add('SELECT typenebestela_id FROM typenebestela WHERE typenebestela = "' + DBLCBTypeNebesTela.Text + '"');
      SQLQuery1.Open;
      ClientDataSet1.Active := true;
      BuftypenebestelaStr := VarToStr(SQLQuery1.FieldValues['typenebestela_id']);

      ClientDataSet1.Active := false;
      SQLQuery1.Close;
      SQLQuery1.SQL.Clear;
      SQLQuery1.SQL.Add('SELECT golak_id FROM golak WHERE galak_name = "' + DBLCBGolak.Text + '"');
      SQLQuery1.Open;
      ClientDataSet1.Active := true;
      BufGolakStr := VarToStr(SQLQuery1.FieldValues['golak_id']);

      BufNebessvazID := 0;
      BufHNebessvazStr := '';
      ClientDataSet1.Active := false;
      SQLQuery1.Close;
      SQLQuery1.SQL.Clear;
      SQLQuery1.SQL.Add('SELECT MAX(nebessvaz_id) AS ID FROM Nebessvaz');
      SQLQuery1.Open;
      ClientDataSet1.Active := true;
      BufHNebessvazStr := IntToStr(SQLQuery1.FieldValues['ID']);
      BufNebessvazID := StrToInt(BufHNebessvazStr) + 1;

      SQLQuery1.SQL.Clear;
      SQLQuery1.SQL.Add('INSERT INTO nebessvaz (NebesSvaz_id, NebesTela, Opisanie, typenebestela_id, golak_id) VALUES(');
      SQLQuery1.SQL.Add(IntToStr(BufNebessvazID) + ', "' + EditNebesTela.Text + '", "');
      for I := 0 to Memo1.Lines.Count do
        SQLQuery1.SQL.Add(Memo1.Lines[i]);
      SQLQuery1.SQL.Add('", ' + BuftypenebestelaStr + ', ' + BufGolakStr + ')');
      SQLQuery1.ExecSQL;

      ShowMessage('���������!');

      FormProg.ClientDataSet1.Active := false;
      FormProg.SQLQuery1.Close;
      FormProg.SQLQuery1.SQL.Clear;
      FormProg.SQLQuery1.SQL.Add('SELECT nebessvaz_id, golak.golak_id, typenebestela.typenebestela_ID, Opisanie, nebessvaz.nebestela,typenebestela.typenebestela, golak.galak_name ');
      FormProg.SQLQuery1.SQL.Add('FROM  nebessvaz,typenebestela,golak ');
      FormProg.SQLQuery1.SQL.Add('WHERE golak.golak_id = nebessvaz.golak_id ');
      FormProg.SQLQuery1.SQL.Add('AND typenebestela.typenebestela_id = nebessvaz.typenebestela_id');
      FormProg.SQLQuery1.Open;
      FormProg.ClientDataSet1.Active := true;
      FormProg.DbGrid1.Refresh;
end;

procedure TForm8.Button2Click(Sender: TObject);
  Var BuftypenebestelaStr, BufHNebessvazStr, BufGolakStr : string;
    BufnebessvazID, i : integer;
begin
      ClientDataSet1.Active := false;
      SQLQuery1.Close;
      SQLQuery1.SQL.Clear;
      SQLQuery1.SQL.Add('SELECT typenebestela_id FROM typenebestela WHERE typenebestela = "' + DBLCBTypeNebesTela.Text + '"');
      SQLQuery1.Open;
      ClientDataSet1.Active := true;
      BuftypenebestelaStr := VarToStr(SQLQuery1.FieldValues['typenebestela_id']);

      ClientDataSet1.Active := false;
      SQLQuery1.Close;
      SQLQuery1.SQL.Clear;
      SQLQuery1.SQL.Add('SELECT golak_id FROM golak WHERE galak_name = "' + DBLCBGolak.Text + '"');
      SQLQuery1.Open;
      ClientDataSet1.Active := true;
      BufGolakStr := VarToStr(SQLQuery1.FieldValues['golak_id']);

      BufNebessvazID := 0;
      BufHNebessvazStr := '';
      ClientDataSet1.Active := false;
      SQLQuery1.Close;
      SQLQuery1.SQL.Clear;
      SQLQuery1.SQL.Add('SELECT MAX(nebessvaz_id) AS ID FROM Nebessvaz');
      SQLQuery1.Open;
      ClientDataSet1.Active := true;
      BufHNebessvazStr := IntToStr(SQLQuery1.FieldValues['ID']);
      BufNebessvazID := StrToInt(BufHNebessvazStr) + 1;

      SQLQuery1.Close;
      SQLQuery1.SQL.Clear;
      SQLQuery1.SQL.Add('UPDATE nebessvaz SET NebesTela = "' + EditNebesTela.Text + '", Opisanie = "');
      for I := 0 to Memo1.Lines.Count do
        SQLQuery1.SQL.Add(Memo1.Lines[i]);
      SQLQuery1.SQL.Add('", typenebestela_id = ' + BuftypenebestelaStr + ', golak_id = ' + BufGolakStr + ' WHERE nebessvaz_ID = ' + DBEdit1.Text);
      SQLQuery1.ExecSQL;

      ShowMessage('��������!');

      FormProg.ClientDataSet1.Active := false;
      FormProg.SQLQuery1.Close;
      FormProg.SQLQuery1.SQL.Clear;
      FormProg.SQLQuery1.SQL.Add('SELECT nebessvaz_id, golak.golak_id, typenebestela.typenebestela_ID, Opisanie, nebessvaz.nebestela,typenebestela.typenebestela, golak.galak_name ');
      FormProg.SQLQuery1.SQL.Add('FROM  nebessvaz,typenebestela,golak ');
      FormProg.SQLQuery1.SQL.Add('WHERE golak.golak_id = nebessvaz.golak_id ');
      FormProg.SQLQuery1.SQL.Add('AND typenebestela.typenebestela_id = nebessvaz.typenebestela_id');
      FormProg.SQLQuery1.Open;
      FormProg.ClientDataSet1.Active := true;
      FormProg.DbGrid1.Refresh;
end;

procedure TForm8.Button3Click(Sender: TObject);
begin
      SQLQuery1.Close;
      SQLQuery1.SQL.Clear;
      SQLQuery1.SQL.Add('DELETE FROM nebessvaz WHERE nebessvaz_ID = ' + DBEdit1.Text);
      SQLQuery1.ExecSQL;

      ShowMessage('�������!');

      FormProg.ClientDataSet1.Active := false;
      FormProg.SQLQuery1.Close;
      FormProg.SQLQuery1.SQL.Clear;
      FormProg.SQLQuery1.SQL.Add('SELECT nebessvaz_id, golak.golak_id, typenebestela.typenebestela_ID, Opisanie, nebessvaz.nebestela,typenebestela.typenebestela, golak.galak_name ');
      FormProg.SQLQuery1.SQL.Add('FROM  nebessvaz,typenebestela,golak ');
      FormProg.SQLQuery1.SQL.Add('WHERE golak.golak_id = nebessvaz.golak_id ');
      FormProg.SQLQuery1.SQL.Add('AND typenebestela.typenebestela_id = nebessvaz.typenebestela_id');
      FormProg.SQLQuery1.Open;
      FormProg.ClientDataSet1.Active := true;
      FormProg.DbGrid1.Refresh;
end;

procedure TForm8.Button4Click(Sender: TObject);
begin
  FormNew.Show;
end;

end.
