unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Data.DB, Vcl.Grids, Vcl.DBGrids,
  Data.Win.ADODB, Vcl.StdCtrls, Vcl.ComCtrls, Vcl.DBCtrls, jpeg, Vcl.OleCtnrs,
  Vcl.ExtCtrls, ShellApi, Vcl.ExtDlgs, Vcl.OleCtrls, AcroPDFLib_TLB, DBXMySQL,
  Data.FMTBcd, Datasnap.DBClient, Datasnap.Provider, Data.SqlExpr, Vcl.Menus,
  Vcl.Mask;

type
  TForm1 = class(TForm)
    OpenDialog1: TOpenDialog;
    OpenPictureDialog1: TOpenPictureDialog;
    AcroPDF1: TAcroPDF;
    PageControl1: TPageControl;
    TabSheet1: TTabSheet;
    TabSheet2: TTabSheet;
    Button2: TButton;
    DBGrid1: TDBGrid;
    DBGrid2: TDBGrid;
    BtnSaveEditor: TButton;
    CBCAll: TButton;
    MainMenu1: TMainMenu;
    N1: TMenuItem;
    N3: TMenuItem;
    MMEditor: TMenuItem;
    N5: TMenuItem;
    BtnDelEditor: TButton;
    BtnFound: TButton;
    EditFV_Max: TEdit;
    CBFOperMax: TComboBox;
    CBC2: TButton;
    CBC3: TButton;
    BtnFClear: TButton;
    N6: TMenuItem;
    Label10: TLabel;
    EditFastF: TEdit;
    SQLConnection1: TSQLConnection;
    SQLQuery1: TSQLQuery;
    DataSetProvider1: TDataSetProvider;
    ClientDataSet1: TClientDataSet;
    SQLQuery2: TSQLQuery;
    DataSetProvider2: TDataSetProvider;
    ClientDataSet2: TClientDataSet;
    DataSource2: TDataSource;
    EditIzmerenie: TEdit;
    EditFV_Min: TEdit;
    CBFOperMin: TComboBox;
    SQLQuery3: TSQLQuery;
    DataSetProvider3: TDataSetProvider;
    ClientDataSet3: TClientDataSet;
    DataSource3: TDataSource;
    EditFoundMaxID: TEdit;
    MMAdd: TMenuItem;
    MMEdit: TMenuItem;
    MMDel: TMenuItem;
    MMAll: TMenuItem;
    CBCreate: TComboBox;
    LabelZapis: TLabel;
    EditOboznach: TEdit;
    EditNaim: TEdit;
    BtnSaveAddZapis: TButton;
    LabelCharac: TLabel;
    EditSymbol: TEdit;
    EditV_Min: TEdit;
    EditV_Max: TEdit;
    BtnAddCharac: TButton;
    BtnEdEditor: TButton;
    EEditIzmerenie: TEdit;
    Label1: TLabel;
    DBEditName: TDBEdit;
    BtnEdZapis: TButton;
    BtnEdHandZapis: TButton;
    DBEditOboznach: TDBEdit;
    DBCBNaznach: TDBComboBox;
    DBEditSymbol: TDBEdit;
    DBEditV_Min: TDBEdit;
    DBEditV_Max: TDBEdit;
    DBCBIzmerenie: TDBComboBox;
    BtnDelZapisCharac: TButton;
    BtnAddPDF: TButton;
    BtnDelPDF: TButton;
    DataSource4: TDataSource;
    ClientDataSet4: TClientDataSet;
    DataSetProvider4: TDataSetProvider;
    SQLQuery4: TSQLQuery;
    StaticText1: TStaticText;
    CBFSymbol: TDBLookupComboBox;
    DataSource5: TDataSource;
    ClientDataSet5: TClientDataSet;
    DataSetProvider5: TDataSetProvider;
    SQLQuery5: TSQLQuery;
    SQLQuery6: TSQLQuery;
    DataSetProvider6: TDataSetProvider;
    ClientDataSet6: TClientDataSet;
    DataSource6: TDataSource;
    SQLQuery7: TSQLQuery;
    DataSetProvider7: TDataSetProvider;
    ClientDataSet7: TClientDataSet;
    DataSource7: TDataSource;
    SaveDialog1: TSaveDialog;
    CBIzmerenie: TDBLookupComboBox;
    CBSreda: TDBLookupComboBox;
    CBNaznach: TDBLookupComboBox;
    DataSource1: TDataSource;
    StaticText2: TStaticText;
    StaticText3: TStaticText;
    StaticText4: TStaticText;
    MMClear: TMenuItem;
    SQLQuery8: TSQLQuery;
    DataSetProvider8: TDataSetProvider;
    ClientDataSet8: TClientDataSet;
    DataSource8: TDataSource;
    DBCBSreda: TDBComboBox;
    BtnEdCharac: TButton;
    BtnDelCharac: TButton;
    BtnEdHandCharac: TButton;
    MySite: TMenuItem;
    Image1: TImage;
    Image2: TImage;
    Helper: TMenuItem;
    procedure SQLQuery1AfterScroll(DataSet: TDataSet);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure Button2Click(Sender: TObject);
    procedure FormKeyPress(Sender: TObject; var Key: Char);
    procedure FormShow(Sender: TObject);
    procedure DBGrid1TitleClick(Column: TColumn);
    procedure DBGrid2TitleClick(Column: TColumn);
    procedure FormCreate(Sender: TObject);
    procedure CBCAllClick(Sender: TObject);
    procedure BtnSaveEditorClick(Sender: TObject);
    procedure MMAddClick(Sender: TObject);
    procedure N5Click(Sender: TObject);
    procedure BtnDelEditorClick(Sender: TObject);
    procedure N3Click(Sender: TObject);
    procedure BtnFoundClick(Sender: TObject);
    procedure BtnFClearClick(Sender: TObject);
    procedure N6Click(Sender: TObject);
    procedure EditFastFEnter(Sender: TObject);
    procedure EditFV_MaxClick(Sender: TObject);
    procedure EditFV_MinClick(Sender: TObject);
    procedure ImgAddClick(Sender: TObject);
    procedure EditNaimClick(Sender: TObject);
    procedure EditOboznachClick(Sender: TObject);
    procedure BtnSaveAddZapisClick(Sender: TObject);
    procedure EditSymbolClick(Sender: TObject);
    procedure EditV_MinClick(Sender: TObject);
    procedure EditV_MaxClick(Sender: TObject);
    procedure BtnAddCharacClick(Sender: TObject);
    procedure MMEditClick(Sender: TObject);
    procedure MMAllClick(Sender: TObject);
    procedure EEditIzmerenieClick(Sender: TObject);
    procedure BtnEdEditorClick(Sender: TObject);
    procedure BtnAddPDFClick(Sender: TObject);
    procedure BtnDelPDFClick(Sender: TObject);
    procedure CBFSymbolClick(Sender: TObject);
    procedure CBSredaClick(Sender: TObject);
    procedure CBNaznachClick(Sender: TObject);
    procedure CBIzmerenieClick(Sender: TObject);
    procedure BtnEdZapisClick(Sender: TObject);
    procedure BtnEdHandZapisClick(Sender: TObject);
    procedure BtnDelZapisCharacClick(Sender: TObject);
    procedure BtnDelCharacClick(Sender: TObject);
    procedure BtnEdCharacClick(Sender: TObject);
    procedure BtnEdHandCharacClick(Sender: TObject);
    procedure MMDelClick(Sender: TObject);
    procedure MMClearClick(Sender: TObject);
    procedure MySiteClick(Sender: TObject);
    procedure EditFV_MinKeyPress(Sender: TObject; var Key: Char);
    procedure EditFV_MaxKeyPress(Sender: TObject; var Key: Char);
    procedure EditV_MinKeyPress(Sender: TObject; var Key: Char);
    procedure EditV_MaxKeyPress(Sender: TObject; var Key: Char);
    procedure HelperClick(Sender: TObject);
  private

    procedure CreateParams(VAR Params: TCreateParams);
override;

  public
    { Public declarations }
  end;

var
  Form1 : TForm1;
  ID_s : string;
  Ref, CBI : Integer;
  LUser, SQLAD, SQLFound, FoundAfterScroll : boolean;
  usOb, usNa, usCaption, usCaptionC, usMin, usMax, usSymb, usV_Min, usV_max : boolean;

implementation

{$R *.dfm}

uses Unit2, Unit4, Unit7;

procedure TForm1.CreateParams(VAR Params: TCreateParams);
begin
  Inherited CreateParams(Params);
  WITH Params DO
  ExStyle := ExStyle OR WS_EX_APPWINDOW;
end;

procedure TForm1.DBGrid1TitleClick(Column: TColumn);
begin
  case Column.Index of
  1:
    begin
      ClientDataSet1.Active := false;
      SQLQuery1.Close;
      SQLQuery1.SQL.Clear;
      if SQLAD = true then
        begin
          SQLQuery1.SQL.Add('SELECT Drawing.ID, Drawing.Designation, Drawing.Name, Conditions.Appointment, Environment.Appointment, Image FROM Drawing, Conditions, Environment ');
          SQLQuery1.SQL.Add('WHERE Drawing.ID_Conditions = Conditions.ID AND Drawing.ID_Environment = Environment.ID ORDER BY Designation ASC');
          SQLAD := false;
        end
      else
        begin
          SQLQuery1.SQL.Add('SELECT Drawing.ID, Drawing.Designation, Drawing.Name, Conditions.Appointment, Environment.Appointment, Image FROM Drawing, Conditions, Environment ');
          SQLQuery1.SQL.Add('WHERE Drawing.ID_Conditions = Conditions.ID AND Drawing.ID_Environment = Environment.ID ORDER BY Designation DESC');
          SQLAD := true;
        end;
      SQLQuery1.Open;
      ClientDataSet1.Active := true;
      DBGrid1.SetFocus;
    end;
  3:
    begin
      ClientDataSet1.Active := false;
      SQLQuery1.Close;
      SQLQuery1.SQL.Clear;
      if SQLAD = true then
        begin
          SQLQuery1.SQL.Add('SELECT Drawing.ID, Drawing.Designation, Drawing.Name, Conditions.Appointment, Environment.Appointment, Image FROM Drawing, Conditions, Environment ');
          SQLQuery1.SQL.Add('WHERE Drawing.ID_Conditions = Conditions.ID AND Drawing.ID_Environment = Environment.ID ORDER BY ID_Conditions ASC');
          SQLAD := false;
        end
      else
        begin
          SQLQuery1.SQL.Add('SELECT Drawing.ID, Drawing.Designation, Drawing.Name, Conditions.Appointment, Environment.Appointment, Image FROM Drawing, Conditions, Environment ');
          SQLQuery1.SQL.Add('WHERE Drawing.ID_Conditions = Conditions.ID AND Drawing.ID_Environment = Environment.ID ORDER BY ID_Conditions DESC');
          SQLAD := true;
        end;
      SQLQuery1.Open;
      ClientDataSet1.Active := true;
      DBGrid1.SetFocus;
    end;
  4:
    begin
      ClientDataSet1.Active := false;
      SQLQuery1.Close;
      SQLQuery1.SQL.Clear;
      if SQLAD = true then
        begin
          SQLQuery1.SQL.Add('SELECT Drawing.ID, Drawing.Designation, Drawing.Name, Conditions.Appointment, Environment.Appointment, Image FROM Drawing, Conditions, Environment ');
          SQLQuery1.SQL.Add('WHERE Drawing.ID_Conditions = Conditions.ID AND Drawing.ID_Environment = Environment.ID ORDER BY ID_Environment ASC');
          SQLAD := false;
        end
      else
        begin
          SQLQuery1.SQL.Add('SELECT Drawing.ID, Drawing.Designation, Drawing.Name, Conditions.Appointment, Environment.Appointment, Image FROM Drawing, Conditions, Environment ');
          SQLQuery1.SQL.Add('WHERE Drawing.ID_Conditions = Conditions.ID AND Drawing.ID_Environment = Environment.ID ORDER BY ID_Environment DESC');
          SQLAD := true;
        end;
      SQLQuery1.Open;
      ClientDataSet1.Active := true;
      DBGrid1.SetFocus;
    end;
  end;

end;

procedure TForm1.DBGrid2TitleClick(Column: TColumn);
begin
  case Column.Index of
  1:
    begin
      ClientDataSet2.Active := false;
      SQLQuery2.Close;
      SQLQuery2.SQL.Clear;
      if SQLAD = true then
        begin
          SQLQuery2.SQL.Add('SELECT Characteristics.Id, Characteristics.Symbol, V_min, V_max, Designation.Designation FROM Drawing, Characteristics, Designation ');
          SQLQuery2.SQL.Add('WHERE Drawing.ID_Characteristics = Characteristics.ID AND Characteristics.ID_Designation = Designation.ID ORDER BY ' + Column.FieldName + ' ASC');
          SQLAD := false;
        end
      else
        begin
          SQLQuery2.SQL.Add('SELECT Characteristics.Id, Characteristics.Symbol, V_min, V_max, Designation.Designation FROM Drawing, Characteristics, Designation ');
          SQLQuery2.SQL.Add('WHERE Drawing.ID_Characteristics = Characteristics.ID AND Characteristics.ID_Designation = Designation.ID ORDER BY ' + Column.FieldName + ' DESC');
          SQLAD := true;
        end;
      SQLQuery2.Open;
      ClientDataSet2.Active := true;
      DBGrid2.SetFocus;
    end;
  2:
    begin
      ClientDataSet2.Active := false;
      SQLQuery2.Close;
      SQLQuery2.SQL.Clear;
      if SQLAD = true then
        begin
          SQLQuery2.SQL.Add('SELECT Characteristics.Id, Characteristics.Symbol, V_min, V_max, Designation.Designation FROM Drawing, Characteristics, Designation ');
          SQLQuery2.SQL.Add('WHERE Drawing.ID_Characteristics = Characteristics.ID AND Characteristics.ID_Designation = Designation.ID ORDER BY ' + Column.FieldName + ' ASC');
          SQLAD := false;
        end
      else
        begin
          SQLQuery2.SQL.Add('SELECT Characteristics.Id, Characteristics.Symbol, V_min, V_max, Designation.Designation FROM Drawing, Characteristics, Designation ');
          SQLQuery2.SQL.Add('WHERE Drawing.ID_Characteristics = Characteristics.ID AND Characteristics.ID_Designation = Designation.ID ORDER BY ' + Column.FieldName + ' DESC');
          SQLAD := true;
        end;
      SQLQuery2.Open;
      ClientDataSet2.Active := true;
      DBGrid2.SetFocus;
    end;
  3:
    begin
      ClientDataSet2.Active := false;
      SQLQuery2.Close;
      SQLQuery2.SQL.Clear;
      if SQLAD = true then
        begin
          SQLQuery2.SQL.Add('SELECT Characteristics.Id, Characteristics.Symbol, V_min, V_max, Designation.Designation FROM Drawing, Characteristics, Designation ');
          SQLQuery2.SQL.Add('WHERE Drawing.ID_Characteristics = Characteristics.ID AND Characteristics.ID_Designation = Designation.ID ORDER BY ID_Designation ASC');
          SQLAD := false;
        end
      else
        begin
          SQLQuery2.SQL.Add('SELECT Characteristics.Id, Characteristics.Symbol, V_min, V_max, Designation.Designation FROM Drawing, Characteristics, Designation ');
          SQLQuery2.SQL.Add('WHERE Drawing.ID_Characteristics = Characteristics.ID AND Characteristics.ID_Designation = Designation.ID ORDER BY ID_Designation DESC');
          SQLAD := true;
        end;
      SQLQuery2.Open;
      ClientDataSet2.Active := true;
      DBGrid2.SetFocus;
    end;
  4:
    begin
      ClientDataSet2.Active := false;
      SQLQuery2.Close;
      SQLQuery2.SQL.Clear;
      if SQLAD = true then
        begin
          SQLQuery2.SQL.Add('SELECT Characteristics.Id, Symbol, V_min, V_max, Designation.Designation FROM Drawing, Characteristics, Designation ');
          SQLQuery2.SQL.Add('WHERE Drawing.ID_Characteristics = Characteristics.ID AND Characteristics.ID_Designation = Designation.ID ORDER BY ' + Column.FieldName + ' DESC');
          SQLAD := false;
        end
      else
        begin
          SQLQuery2.SQL.Add('SELECT Characteristics.Id, Symbol, V_min, V_max, Designation.Designation FROM Drawing, Characteristics, Designation ');
          SQLQuery2.SQL.Add('WHERE Drawing.ID_Characteristics = Characteristics.ID AND Characteristics.ID_Designation = Designation.ID ORDER BY ' + Column.FieldName + ' ASC');
          SQLAD := true;
        end;
      SQLQuery2.Open;
      ClientDataSet2.Active := true;
      DBGrid2.SetFocus;
    end;
  end;
end;

procedure TForm1.EditOboznachClick(Sender: TObject);
begin
  EditOboznach.Font.Style := [];
  if usOb <> true then
    EditOboznach.Text := '';
  usOb := true;
end;

procedure TForm1.EditSymbolClick(Sender: TObject);
begin
  EditSymbol.Font.Style := [];
  if usSymb <> true then
    EditSymbol.Text := '';
  usSymb := true;
end;

procedure TForm1.EditV_MaxClick(Sender: TObject);
begin
  EditV_Max.Font.Style := [];
  if usMax <> true then
    EditV_Max.Text := '';
  usMax := true;
end;

procedure TForm1.EditV_MaxKeyPress(Sender: TObject; var Key: Char);
begin
  if not(Key in ['0'..'9']) and not(Key in ['.']) then Key:=#0;
end;

procedure TForm1.EditV_MinClick(Sender: TObject);
begin
  EditV_Min.Font.Style := [];
  if usMin <> true then
    EditV_Min.Text := '';
  usMin := true;
end;

procedure TForm1.EditV_MinKeyPress(Sender: TObject; var Key: Char);
begin
  if not(Key in ['0'..'9']) and not(Key in ['.']) then Key:=#0;
end;

procedure TForm1.EEditIzmerenieClick(Sender: TObject);
begin
  EEditIzmerenie.Text := '';
end;

procedure TForm1.EditFastFEnter(Sender: TObject);
Var buf : string;
begin
  buf := EditFastF.Text + '%';
  ClientDataSet1.Active := false;
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('SELECT DISTINCT Drawing.ID,Drawing.Designation,Name,Conditions.Appointment,Environment.Appointment FROM Drawing,Conditions,Characteristics,Environment ');
  SQLQuery1.SQL.Add('WHERE Drawing.ID_Conditions = Conditions.ID AND Drawing.ID_Environment = Environment.ID AND Drawing.ID_Characteristics = Characteristics.ID ');
  SQLQuery1.SQL.Add('AND (Drawing.Designation LIKE "' + buf + '%" OR Name LIKE "' + buf + '%" OR Conditions.Appointment LIKE "' + buf + '%" OR Environment.Appointment LIKE "' + buf + '%")');
  SQLQuery1.Open;
  ClientDataSet1.Active := true;
end;

procedure TForm1.EditFV_MaxClick(Sender: TObject);
begin
  if usV_Max <> true then
    begin
      EditFV_Max.Font.Style := [];
      EditFV_Max.Text := '';
    end;
  usV_Max := true;
end;

procedure TForm1.EditFV_MaxKeyPress(Sender: TObject; var Key: Char);
begin
  if not(Key in ['0'..'9']) and not(Key in ['.']) then Key:=#0;
end;

procedure TForm1.EditFV_MinClick(Sender: TObject);
begin
  if usV_Min <> true then
    begin
      EditFV_Min.Font.Style := [];
      EditFV_Min.Text := '';
    end;
  usV_Min := true;
end;

procedure TForm1.EditFV_MinKeyPress(Sender: TObject; var Key: Char);
begin
  if not(Key in ['0'..'9']) and not(Key in ['.']) then Key:=#0;
end;

procedure TForm1.EditNaimClick(Sender: TObject);
Var us : boolean;
begin
  EditNaim.Font.Style := [];
  if usNa <> true then
    EditNaim.Text := '';
  usNa := true;
end;

procedure TForm1.SQLQuery1AfterScroll(DataSet: TDataSet);
  var FileName: string;
begin
{  if FoundAfterScroll then
    begin
      ID_s := DBGrid1.Fields[0].Value;
    end; }

  {if FoundAfterScroll = true then
    begin
      ClientDataSet2.Active := false;
      ID_s := DBGrid1.Fields[0].Value;
      SQLQuery2.Close;
      SQLQuery2.SQL.Clear;
      SQLQuery2.SQL.Add('Select Symbol, V_min, V_max, Designation.Designation FROM Characteristics, Designation WHERE Characteristics.Designation = Designation.ID AND Characteristics.ID = ' + ID_s);
      SQLQuery2.Open;
      ClientDataSet2.Active := true;
    end;}
end;

procedure TForm1.BtnSaveAddZapisClick(Sender: TObject);
Var bufID : integer;
    bufNaznach, bufSreda : string;
begin
  if (EditOboznach.Text = '') or (EditOboznach.Text = '�����������') then
    begin
      ShowMessage('������� �����������.');
      exit;
    end;

  ClientDataSet3.Active := false;
   SQLQuery3.Close;
    SQLQuery3.SQL.Clear;
     SQLQuery3.SQL.Add('SELECT Designation FROM Drawing WHERE Designation = "' + EditOboznach.Text + '"');
      SQLQuery3.Open;
       ClientDataSet3.Active := true;
  EditFoundMaxID.Text := VarToStr(SQLQuery3.FieldValues['Designation']);
    if EditFoundMaxID.Text = EditOboznach.Text then
      begin
        ShowMessage('����� ������ ��� ����������.');
        Exit;
      end;
  EditFoundMaxID.Text := '';

  if (EditNaim.Text = '') or (EditNaim.Text = '������������') then
    begin
      ShowMessage('������� ������������.');
      exit;
    end;
  if (CBNaznach.Text = '') then
    begin
      ShowMessage('�������� ����������.');
      exit;
    end;
  if (CBSreda.Text = '') then
    begin
      ShowMessage('�������� �����.');
      exit;
    end;

  ClientDataSet3.Active := false;
   SQLQuery3.Close;
    SQLQuery3.SQL.Clear;
     SQLQuery3.SQL.Add('SELECT ID FROM Conditions WHERE Appointment = "' + CBNaznach.Text + '"');
      SQLQuery3.Open;
       ClientDataSet3.Active := true;
  bufNaznach := VarToStr(SQLQuery3.FieldValues['ID']);

  ClientDataSet3.Active := false;
   SQLQuery3.Close;
    SQLQuery3.SQL.Clear;
     SQLQuery3.SQL.Add('SELECT ID FROM Environment WHERE Appointment = "' + CBSreda.Text + '"');
      SQLQuery3.Open;
       ClientDataSet3.Active := true;
  bufSreda := VarToStr(SQLQuery3.FieldValues['ID']);

  bufID := 0;
  ClientDataSet3.Active := false;
   SQLQuery3.Close;
    SQLQuery3.SQL.Clear;
     SQLQuery3.SQL.Add('SELECT MAX(ID) AS ID FROM Drawing');
      SQLQuery3.Open;
       ClientDataSet3.Active := true;
  EditFoundMaxID.Text := IntToStr(SQLQuery3.FieldValues['ID']);
  bufID := StrToInt(EditFoundMaxID.Text) + 1;

  SQLQuery3.SQL.Clear;
   SQLQuery3.SQL.Add('INSERT INTO Drawing (ID, Designation, ID_Characteristics, Name, ID_Environment, ID_Conditions) VALUES(');
    SQLQuery3.SQL.Add(IntToStr(bufID) + ', "' + EditOboznach.Text + '", ' + IntToStr(bufID) + ', "' + EditNaim.Text + '", ');
     SQLQuery3.SQL.Add(bufSreda + ', ' + bufNaznach + ')');
      SQLQuery3.ExecSQL;

       {if OpenDialog1.Execute Then
       begin
         SQLQuery3.SQL.Text := 'UPDATE Drawing SET Image = :img WHERE ID = ' + IntToStr(bufID);
         SQLQuery3.ParamByName('img').LoadFromFile(OpenDialog1.FileName, ftblob);
         SQLQuery3.ExecSQL;
       end;}

  N6Click(Self);
  DBGrid1.DataSource.DataSet.Last;
end;

procedure TForm1.BtnSaveEditorClick(Sender: TObject);
Var bufID, i : integer;
begin
  if CBCreate.ItemIndex < 0 then
    begin
      ShowMessage('�������� �������� �� ������.');
      exit;
    end;
  if EditIzmerenie.Text = '' then
    begin
      ShowMessage('������� ����� �������.');
      exit;
    end;

  bufID := 0;
  ClientDataSet3.Active := false;
  SQLQuery3.Close;
  SQLQuery3.SQL.Clear;
  if CBCreate.ItemIndex = 0 then
    begin
      SQLQuery3.SQL.Add('SELECT Appointment FROM Environment WHERE Appointment = "' + EditIzmerenie.Text + '"');
      SQLQuery3.Open;
      ClientDataSet3.Active := true;
      EditFoundMaxID.Text := VarToStr(SQLQuery3.FieldValues['Appointment']);
      if EditFoundMaxID.Text = EditIzmerenie.Text then
      begin
        ShowMessage('����� ������������ ��� ����������.');
        Exit;
      end;
      EditFoundMaxID.Text := '';

      ClientDataSet3.Active := false;
      SQLQuery3.Close;
      SQLQuery3.SQL.Clear;
      SQLQuery3.SQL.Add('SELECT MAX(ID) AS ID FROM Environment');
      SQLQuery3.Open;
      ClientDataSet3.Active := true;

      EditFoundMaxID.Text := IntToStr(SQLQuery3.FieldValues['ID']);
      bufID := StrToInt(EditFoundMaxID.Text) + 1;
      SQLQuery3.SQL.Clear;
      SQLQuery3.SQL.Add('INSERT INTO Environment (ID, Appointment) VALUES(' + IntToStr(bufID) + ', "' + EditIzmerenie.Text + '")');
      for i := 0 to DBCBSreda.Items.Count do
        if EditIzmerenie.Text <> DBCBSreda.Items.Strings[i-1] then
          begin
            DBCBSreda.Items.Add(EditIzmerenie.Text);
            Break;
          end;
    end;
  if CBCreate.ItemIndex = 1 then
    begin
      SQLQuery3.SQL.Add('SELECT Appointment FROM Conditions WHERE Appointment = "' + EditIzmerenie.Text + '"');
      SQLQuery3.Open;
      ClientDataSet3.Active := true;
      EditFoundMaxID.Text := VarToStr(SQLQuery3.FieldValues['Appointment']);
      if EditFoundMaxID.Text = EditIzmerenie.Text then
      begin
        ShowMessage('����� ������������ ��� ����������.');
        Exit;
      end;
      EditFoundMaxID.Text := '';

      ClientDataSet3.Active := false;
      SQLQuery3.Close;
      SQLQuery3.SQL.Clear;
      SQLQuery3.SQL.Add('SELECT MAX(ID) AS ID FROM Conditions');
      SQLQuery3.Open;
      ClientDataSet3.Active := true;
      EditFoundMaxID.Text := IntToStr(SQLQuery3.FieldValues['ID']);
      bufID := StrToInt(EditFoundMaxID.Text) + 1;
      SQLQuery3.SQL.Clear;
      SQLQuery3.SQL.Add('INSERT INTO Conditions (ID, Appointment) VALUES(' + IntToStr(bufID) + ', "' + EditIzmerenie.Text + '")');
      for i := 0 to DBCBNaznach.Items.Count do
        if EditIzmerenie.Text <> DBCBNaznach.Items.Strings[i-1] then
          begin
            DBCBNaznach.Items.Add(EditIzmerenie.Text);
            Break;
          end;
    end;
  if CBCreate.ItemIndex = 2 then
    begin
      SQLQuery3.SQL.Add('SELECT Designation FROM Designation WHERE Designation = "' + EditIzmerenie.Text + '"');
      SQLQuery3.Open;
      ClientDataSet3.Active := true;
      EditFoundMaxID.Text := VarToStr(SQLQuery3.FieldValues['Designation']);
      if EditFoundMaxID.Text = EditIzmerenie.Text then
      begin
        ShowMessage('����� ������������ ��� ����������.');
        Exit;
      end;
      EditFoundMaxID.Text := '';

      ClientDataSet3.Active := false;
      SQLQuery3.Close;
      SQLQuery3.SQL.Clear;
      SQLQuery3.SQL.Add('SELECT MAX(ID) AS ID FROM Designation');
      SQLQuery3.Open;
      ClientDataSet3.Active := true;
      EditFoundMaxID.Text := IntToStr(SQLQuery3.FieldValues['ID']);
      bufID := StrToInt(EditFoundMaxID.Text) + 1;
      SQLQuery3.SQL.Clear;
      SQLQuery3.SQL.Add('INSERT INTO Designation (ID, Designation) VALUES(' + IntToStr(bufID) + ', "' + EditIzmerenie.Text + '")');
      for i := 0 to DBCBIzmerenie.Items.Count do
        if EditIzmerenie.Text <> DBCBIzmerenie.Items.Strings[i-1] then
          begin
            DBCBIzmerenie.Items.Add(EditIzmerenie.Text);
            Break;
          end;
    end;
  CBIzmerenie.Refresh;
  DBCBIzmerenie.Refresh;
  SQLQuery3.ExecSQL;
  EEditIzmerenie.Text := EditIzmerenie.Text;
end;

procedure TForm1.BtnAddCharacClick(Sender: TObject);
  Var bufID : integer;
      bufIzmerenie : string;
      dec1,dec2:Extended;
begin
if (EditV_Min.Text = 'V_Min') then
  begin
    ShowMessage('������� ������� "V_Min".');
    exit;
  end;
if (EditV_Max.Text = 'V_Max') then
  begin
    ShowMessage('������� ������� "V_Max" � ������� ��������.');
    exit;
  end;
if (EditV_Max.Text = '') then
  begin
    ShowMessage('������� "V_Max"');
    exit;
  end;
if (EditSymbol.Text = '������') then
  begin
    ShowMessage('������� ������� "������" � ������� ��������.');
    exit;
  end;
if (EditSymbol.Text = '') then
  begin
    ShowMessage('������� "������"');
    exit;
  end;
if (CBIzmerenie.Text = '') then
  begin
    ShowMessage('�������� ������� ���������.');
    exit;
  end;

  ID_s := DBGrid1.Fields[0].Value;

       bufID := 0;
       ClientDataSet3.Active := false;
        SQLQuery3.Close;
         SQLQuery3.SQL.Clear;
          SQLQuery3.SQL.Add('SELECT MAX(ID_) AS ID FROM Characteristics');
           SQLQuery3.Open;
            ClientDataSet3.Active := true;
       EditFoundMaxID.Text := IntToStr(SQLQuery3.FieldValues['ID']);
       bufID := StrToInt(EditFoundMaxID.Text) + 1;

       ClientDataSet3.Active := false;
        SQLQuery3.Close;
         SQLQuery3.SQL.Clear;
          SQLQuery3.SQL.Add('SELECT ID FROM Designation WHERE Designation = "' + CBIzmerenie.Text + '"');
           SQLQuery3.Open;
            ClientDataSet3.Active := true;
       bufIzmerenie := VarToStr(SQLQuery3.FieldValues['ID']);

  SQLQuery3.SQL.Clear;
   SQLQuery3.SQL.Add('INSERT INTO Characteristics (Characteristics.ID_, Characteristics.ID, Characteristics.Symbol, ');
  if EditV_Min.Text <> '' then
     SQLQuery3.SQL.Add('Characteristics.V_Min, ');
   SQLQuery3.SQL.Add('Characteristics.V_Max, Characteristics.ID_Designation) VALUES(');
     SQLQuery3.SQL.Add(IntToStr(bufID) + ', ' + ID_s + ', "' + EditSymbol.Text + '", ');
  if EditV_Min.Text <> '' then
    SQLQuery3.SQL.Add(':dec1, ');
  SQLQuery3.SQL.Add(':dec2, ' + bufIzmerenie + ')');
  if EditV_Min.Text <> '' then
    SQLQuery3.ParamByName('dec1').asFloat:=StrToFloat(EditV_Min.Text);
  SQLQuery3.ParamByName('dec2').asFloat:=StrToFloat(EditV_Max.Text);
       SQLQuery3.ExecSQL;

  N6Click(Self);
  DBGrid1.DataSource.DataSet.Locate('ID', ID_s, [loCaseInsensitive, loPartialKey]);
end;

procedure TForm1.BtnAddPDFClick(Sender: TObject);
Var PicWithAPDF: Tmemorystream;
begin
  if FileExists('temp\buf.pdf') then
    DeleteFile('temp\buf.pdf');

      ID_s := DBGrid1.Fields[0].Value;
      ClientDataSet3.Active := false;
       SQLQuery3.Close;
        SQLQuery3.SQL.Clear;
         SQLQuery3.SQL.Add('SELECT * FROM Drawing WHERE ID = ' + ID_s);
          SQLQuery3.Open;
           ClientDataSet3.Active := true;
      PicWithAPDF := Tmemorystream.Create;
      TBLOBField(Form1.SQLQuery3.FieldByName('Image')).SaveToStream(PicWithAPDF);
      PicWithAPDF.Position := 0;
      PicWithAPDF.SaveToFile('temp\buf.pdf');
      PicWithAPDF.SaveToFile('temp\temp.pdf');
      FreeAndNil(PicWithAPDF);
      if FileExists('temp\buf.pdf') then
        FormPDF.acropdf1.LoadFile('temp\buf.pdf');

  FormPDF.Show;
  FormPDF.Caption := '��������� �����������';
  FormPDF.Button1.Caption := '��������';
end;

procedure TForm1.BtnDelCharacClick(Sender: TObject);
begin
if (EditSymbol.Text = '������') then
  begin
    ShowMessage('������� ������� "������" � ������� ��������.');
    exit;
  end;
if (EditSymbol.Text = '') then
  begin
    ShowMessage('������� "������"');
    exit;
  end;
  ClientDataSet3.Active := false;
  SQLQuery3.Close;
  SQLQuery3.SQL.Clear;
  SQLQuery3.SQL.Add('SELECT Symbol FROM Characteristics WHERE ID = ' + ID_s + ' AND Symbol = "' + EditSymbol.Text + '"');
  SQLQuery3.Open;
  ClientDataSet3.Active := true;
  EditFoundMaxID.Text := VarToStr(SQLQuery3.FieldValues['Symbol']);
    if EditFoundMaxID.Text <> EditSymbol.Text then
      begin
        ShowMessage('����� �������������� �� ����������.');
        Exit;
      end;
  EditFoundMaxID.Text := '';

  ID_s := DBGrid1.Fields[0].Value;

  SQLQuery3.SQL.Clear;
  SQLQuery3.SQL.Add('DELETE FROM Characteristics WHERE ID = ' + ID_s + ' AND Symbol = "' + EditSymbol.Text + '"');
  SQLQuery3.ExecSQL;

  ClientDataSet2.Active := false;
   SQLQuery2.Close;
    SQLQuery2.SQL.Clear;
     SQLQuery2.SQL.Add('SELECT Characteristics.Id, Characteristics.Symbol, Characteristics.V_min, Characteristics.V_max, Designation.Designation');
      SQLQuery2.SQL.Add(' FROM Characteristics, Designation WHERE Characteristics.ID_Designation = Designation.ID');
       SQLQuery2.Open;
        ClientDataSet2.Active := true;
  DataSource2.DataSet.Active := false;
   DataSource2.DataSet.Active := true;
    DBGrid2.Refresh;
  DBGrid1.DataSource.DataSet.Locate('ID', ID_s, [loCaseInsensitive, loPartialKey]);
end;

procedure TForm1.BtnDelEditorClick(Sender: TObject);
Var i : integer;
begin
  if CBCreate.ItemIndex < 0 then
    begin
      ShowMessage('�������� �������� �� ������.');
      exit;
    end;
  if EditIzmerenie.Text = '' then
    begin
      ShowMessage('������� ��������� �������.');
      exit;
    end;
  if CBCreate.ItemIndex = 0 then
    begin
      ClientDataSet3.Active := false;
      SQLQuery3.Close;
      SQLQuery3.SQL.Clear;
      SQLQuery3.SQL.Add('SELECT Appointment FROM Environment WHERE Appointment = "' + EEditIzmerenie.Text + '"');
      SQLQuery3.Open;
      ClientDataSet3.Active := true;
      EditFoundMaxID.Text := VarToStr(SQLQuery3.FieldValues['Appointment']);
      if EditFoundMaxID.Text <> EEditIzmerenie.Text then
      begin
        ShowMessage('����� ������������ �� ����������.');
        Exit;
      end;
      EditFoundMaxID.Text := '';

      SQLQuery3.SQL.Clear;
      SQLQuery3.SQL.Add('DELETE FROM Environment WHERE Appointment = "' + EditIzmerenie.Text + '"');
      for i := 0 to DBCBSreda.Items.Count do
        if EditIzmerenie.Text = DBCBSreda.Items.Strings[i-1] then
          DBCBSreda.Items.Delete(i-1);
      CBNaznach.Refresh;
      DBCBNaznach.Refresh;
    end;
  if CBCreate.ItemIndex = 1 then
    begin
      ClientDataSet3.Active := false;
      SQLQuery3.Close;
      SQLQuery3.SQL.Clear;
      SQLQuery3.SQL.Add('SELECT Appointment FROM Conditions WHERE Appointment = "' + EEditIzmerenie.Text + '"');
      SQLQuery3.Open;
      ClientDataSet3.Active := true;
      EditFoundMaxID.Text := VarToStr(SQLQuery3.FieldValues['Appointment']);
      if EditFoundMaxID.Text <> EEditIzmerenie.Text then
      begin
        ShowMessage('����� ������������ �� ����������.');
        Exit;
      end;
      EditFoundMaxID.Text := '';

      SQLQuery3.SQL.Clear;
      SQLQuery3.SQL.Add('DELETE FROM Conditions WHERE Appointment = "' + EditIzmerenie.Text + '"');
      for i := 0 to DBCBNaznach.Items.Count do
        if EditIzmerenie.Text = DBCBNaznach.Items.Strings[i-1] then
          DBCBNaznach.Items.Delete(i-1);

      CBSreda.Refresh;
      DBCBSreda.Refresh;
    end;
  if CBCreate.ItemIndex = 2 then
    begin
      ClientDataSet3.Active := false;
      SQLQuery3.Close;
      SQLQuery3.SQL.Clear;
      SQLQuery3.SQL.Add('SELECT Designation FROM Designation WHERE Designation = "' + EEditIzmerenie.Text + '"');
      SQLQuery3.Open;
      ClientDataSet3.Active := true;
      EditFoundMaxID.Text := VarToStr(SQLQuery3.FieldValues['Designation']);
      if EditFoundMaxID.Text <> EEditIzmerenie.Text then
      begin
        ShowMessage('����� ������������ �� ����������.');
        Exit;
      end;
      EditFoundMaxID.Text := '';

      SQLQuery3.SQL.Clear;
      SQLQuery3.SQL.Add('DELETE FROM Designation WHERE Designation = "' + EditIzmerenie.Text + '"');
      for i := 0 to DBCBIzmerenie.Items.Count do
        if EditIzmerenie.Text = DBCBIzmerenie.Items.Strings[i-1] then
          DBCBIzmerenie.Items.Delete(i-1);
      CBIzmerenie.Refresh;
      DBCBIzmerenie.Refresh;
    end;
  SQLQuery3.ExecSQL;
end;

procedure TForm1.BtnDelPDFClick(Sender: TObject);
Var PicWithAPDF: Tmemorystream;
begin
  if FileExists('temp\buf.pdf') then
    DeleteFile('temp\buf.pdf');

      ID_s := DBGrid1.Fields[0].Value;
      ClientDataSet3.Active := false;
       SQLQuery3.Close;
        SQLQuery3.SQL.Clear;
         SQLQuery3.SQL.Add('SELECT * FROM Drawing WHERE ID = ' + ID_s);
          SQLQuery3.Open;
           ClientDataSet3.Active := true;
      PicWithAPDF := Tmemorystream.Create;
      TBLOBField(Form1.SQLQuery3.FieldByName('Image')).SaveToStream(PicWithAPDF);
      PicWithAPDF.Position := 0;
      PicWithAPDF.SaveToFile('temp\buf.pdf');
      PicWithAPDF.SaveToFile('temp\temp.pdf');
      FreeAndNil(PicWithAPDF);
      if FileExists('temp\buf.pdf') then
        FormPDF.acropdf1.LoadFile('temp\buf.pdf');

  FormPDF.Show;
  FormPDF.Caption := '�������� �����������';
  FormPDF.Button1.Caption := '�������';
end;

procedure TForm1.BtnFClearClick(Sender: TObject);
begin
  EditFV_Min.Text := '';
  EditFV_Max.Text := '';
  StaticText1.Visible := true;
end;

procedure TForm1.BtnFoundClick(Sender: TObject);
begin
  ClientDataSet1.Active := false;
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('SELECT DISTINCT Drawing.ID, Drawing.Designation, Drawing.Name, Conditions.Appointment, Environment.Appointment, Image FROM Drawing, Conditions, Environment, Characteristics');
  SQLQuery1.SQL.Add(' WHERE Drawing.ID_Conditions  =  Conditions.ID AND Drawing.ID_Environment = Environment.ID AND drawing.ID_Characteristics = Characteristics.ID');
  if (CBFOperMax.ItemIndex > 0) And (EditFV_Max.Text <> '') And (CBFSymbol.Text <> '') then
    SQLQuery1.SQL.Add(' AND Characteristics.Symbol = "' + CBFSymbol.Text +'" AND Characteristics.V_Max ' + CBFOperMax.Text + ' ' + EditFV_Max.Text);
  if (CBFOperMin.ItemIndex > 0) And (EditFV_Min.Text <> '') And (CBFSymbol.Text <> '') then
    SQLQuery1.SQL.Add(' AND Characteristics.Symbol = "' + CBFSymbol.Text +'" AND Characteristics.V_Min ' + CBFOperMin.Text + ' ' + EditFV_Min.Text);
  SQLQuery1.Open;
  ClientDataSet1.Active := true;

  ClientDataSet2.Active := false;
  SQLQuery2.Close;
  SQLQuery2.SQL.Clear;
  SQLQuery2.SQL.Add('SELECT DISTINCT Drawing.ID, Drawing.Name, Conditions.Appointment, Environment.Appointment, Image, ');
  SQLQuery2.SQL.Add('Characteristics.Id, Characteristics.Symbol, Characteristics.V_min, Characteristics.V_max, Designation.Designation');
  SQLQuery2.SQL.Add(' FROM Drawing, Conditions, Environment, Characteristics, Designation WHERE Characteristics.ID_Designation = Designation.ID');
  SQLQuery2.SQL.Add(' AND Drawing.ID_Conditions  =  Conditions.ID AND Drawing.ID_Environment = Environment.ID AND drawing.ID_Characteristics = Characteristics.ID');
  if (CBFOperMax.ItemIndex > 0) And (EditFV_Max.Text <> '') And (CBFSymbol.Text <> '') then
    SQLQuery2.SQL.Add(' AND Characteristics.Symbol = "' + CBFSymbol.Text +'" AND Characteristics.V_Max ' + CBFOperMax.Text + ' ' + EditFV_Max.Text);
  if (CBFOperMin.ItemIndex > 0) And (EditFV_Min.Text <> '') And (CBFSymbol.Text <> '') then
    SQLQuery2.SQL.Add(' AND Characteristics.Symbol = "' + CBFSymbol.Text +'" AND Characteristics.V_Min ' + CBFOperMin.Text + ' ' + EditFV_Min.Text);
  SQLQuery2.Open;
  ClientDataSet2.Active := true;
end;

procedure TForm1.BtnEdCharacClick(Sender: TObject);
  Var i, bufID : integer;
ShMB : boolean;
bufSymbol, bufIzmerenie, bufOboznach, bufName: string;
bufDBOboznach : string;
begin
  if (EditSymbol.Text = '') or (EditSymbol.Text = '������') then
    begin
      ShowMessage('������� ����� ������.');
      exit;
    end;
  if (DBEditOboznach.Text = '') then
    begin
      ShowMessage('������� ���������� ������.');
      exit;
    end;
  ClientDataSet3.Active := false;
   SQLQuery3.Close;
    SQLQuery3.SQL.Clear;
     SQLQuery3.SQL.Add('SELECT Symbol FROM Characteristics WHERE Symbol = "' + DBEditSymbol.Text + '"');
      SQLQuery3.Open;
       ClientDataSet3.Active := true;
  bufSymbol := VarToStr(SQLQuery3.FieldValues['Symbol']);
    if bufSymbol <> DBEditSymbol.Text then
      begin
        ShowMessage('���������� ������ �� ����������.');
        Exit;
      end;
  if (EditV_Min.Text = 'V_Min') then
    begin
      ShowMessage('������� ����� V_Min.');
      exit;
    end;
  if (DBEditV_Min.Text = '') then
    begin
      ShowMessage('������� ���������� V_Min.');
      exit;
    end;
  if (EditV_Max.Text = 'V_Max') then
    begin
      ShowMessage('������� ����� V_Max.');
      exit;
    end;
  if (DBEditV_Min.Text = '') then
    begin
      ShowMessage('������� ���������� V_Max.');
      exit;
    end;

  if (CBIzmerenie.Text = '') then
    begin
      ShowMessage('�������� ����� ������� ���������.');
      exit;
    end;

  ClientDataSet3.Active := false;
   SQLQuery3.Close;
    SQLQuery3.SQL.Clear;
     SQLQuery3.SQL.Add('SELECT ID FROM Designation WHERE Designation = "' + DBCBIzmerenie.Text + '"');
      SQLQuery3.Open;
       ClientDataSet3.Active := true;
  bufIzmerenie := VarToStr(SQLQuery3.FieldValues['ID']);

  ID_s := DBGrid1.Fields[0].Value;

  ClientDataSet3.Active := false;
   SQLQuery3.Close;
    SQLQuery3.SQL.Clear;
     SQLQuery3.SQL.Add('SELECT ID_ FROM Characteristics WHERE ID_Designation = ' + bufIzmerenie + ' AND Symbol = "' + DBEditSymbol.Text + '" ');
      SQLQuery3.SQL.Add('And V_Min = ' + DBEditV_Min.Text + ' AND V_Max = ' + DBEditV_Max.Text + ' AND ID = ' + ID_s);
       SQLQuery3.Open;
        ClientDataSet3.Active := true;
  EditFoundMaxID.Text := '';

  bufID := 0;
  EditFoundMaxID.Text := VarToStr(SQLQuery3.FieldValues['ID_']);
  if EditFoundMaxID.Text = '' then
    begin
      ShowMessage('�������������� �� �������.');
      exit;
    end;

  ClientDataSet3.Active := false;
   SQLQuery3.Close;
    SQLQuery3.SQL.Clear;
     SQLQuery3.SQL.Add('SELECT ID FROM Designation WHERE Designation = "' + CBIzmerenie.Text + '"');
      SQLQuery3.Open;
       ClientDataSet3.Active := true;
  bufIzmerenie := VarToStr(SQLQuery3.FieldValues['ID']);

  SQLQuery3.Close;
   SQLQuery3.SQL.Clear;
    SQLQuery3.SQL.Add('UPDATE Characteristics SET ID_Designation = ' + bufIzmerenie + ', Symbol = "' + EditSymbol.Text + '", ');
    if EditV_Min.Text = '' then
      SQLQuery3.SQL.Add('V_Min = NULL, V_Max = ' + EditV_Max.Text + ' WHERE ID_ = ' + EditFoundMaxID.Text)
    else
      SQLQuery3.SQL.Add('V_Min = ' + EditV_Min.Text + ', V_Max = ' + EditV_Max.Text + ' WHERE ID_ = ' + EditFoundMaxID.Text);
       SQLQuery3.ExecSQL;

  N6Click(Self);
  DBGrid1.DataSource.DataSet.Locate('ID', ID_s, [loCaseInsensitive, loPartialKey]);
end;

procedure TForm1.BtnEdEditorClick(Sender: TObject);
Var i : integer;
ShMB : boolean;
begin
  if CBCreate.ItemIndex < 0 then
    begin
      ShowMessage('�������� �������������� �� ������.');
      exit;
    end;
  if EEditIzmerenie.Text = '' then
    begin
      ShowMessage('������� ������������� �������.');
      exit;
    end;
  if EditIzmerenie.Text = '' then
    begin
      ShowMessage('������� ���������� �������.');
      exit;
    end;

  ShMB := false;
  ClientDataSet3.Active := false;
  SQLQuery3.Close;
  SQLQuery3.SQL.Clear;
  if CBCreate.ItemIndex = 0 then
    begin
      SQLQuery3.SQL.Add('SELECT Appointment FROM Environment WHERE Appointment = "' + EEditIzmerenie.Text + '"');
      SQLQuery3.Open;
      ClientDataSet3.Active := true;
      EditFoundMaxID.Text := VarToStr(SQLQuery3.FieldValues['Appointment']);
      if EditFoundMaxID.Text <> EEditIzmerenie.Text then
      begin
        ShowMessage('����� ������������ �� ����������.');
        Exit;
      end;
      EditFoundMaxID.Text := '';

      ClientDataSet3.Active := false;
      SQLQuery3.Close;
      SQLQuery3.SQL.Clear;
      SQLQuery3.SQL.Add('UPDATE Environment SET  Appointment = "' + EditIzmerenie.Text + '" ');
      SQLQuery3.SQL.Add('WHERE Appointment = "' + EEditIzmerenie.Text + '"');
      for i := 0 to DBCBSreda.Items.Count do
        if EEditIzmerenie.Text = DBCBSreda.Items.Strings[i-1] then
        begin
          DBCBSreda.Items.Delete(i-1);
          ShMB := false;
          break;
        end
        else
          ShMB := true;
      if ShMB = true then
      begin
        ShowMessage('������ �������� ���.');
        exit;
      end;
      for i := 0 to DBCBSreda.Items.Count do
        if EditIzmerenie.Text <> DBCBSreda.Items.Strings[i-1] then
          begin
            DBCBSreda.Items.Add(EditIzmerenie.Text);
            Break;
          end;
      CBSreda.Refresh;
      DBCBSreda.Refresh;
      EEditIzmerenie.Text := EditIzmerenie.Text;
    end;
  if CBCreate.ItemIndex = 1 then
    begin
      SQLQuery3.SQL.Add('SELECT Appointment FROM Conditions WHERE Appointment = "' + EEditIzmerenie.Text + '"');
      SQLQuery3.Open;
      ClientDataSet3.Active := true;
      EditFoundMaxID.Text := VarToStr(SQLQuery3.FieldValues['Appointment']);
      if EditFoundMaxID.Text <> EEditIzmerenie.Text then
      begin
        ShowMessage('����� ������������ �� ����������.');
        Exit;
      end;
      EditFoundMaxID.Text := '';

      ClientDataSet3.Active := false;
      SQLQuery3.Close;
      SQLQuery3.SQL.Clear;
      SQLQuery3.SQL.Add('UPDATE Conditions SET  Appointment = "' + EditIzmerenie.Text + '" ');
      SQLQuery3.SQL.Add('WHERE Appointment = "' + EEditIzmerenie.Text + '"');
      for i := 0 to DBCBNaznach.Items.Count do
        if EEditIzmerenie.Text = DBCBNaznach.Items.Strings[i-1] then
        begin
          DBCBNaznach.Items.Delete(i-1);
          ShMB := false;
          break;
        end
        else
          ShMB := true;
      if ShMB = true then
      begin
        ShowMessage('������ �������� ���.');
        exit;
      end;
      for i := 0 to DBCBNaznach.Items.Count do
        if EditIzmerenie.Text <> DBCBNaznach.Items.Strings[i-1] then
          begin
            DBCBNaznach.Items.Add(EditIzmerenie.Text);
            Break;
          end;
      CBNaznach.Refresh;
      DBCBNaznach.Refresh;
      EEditIzmerenie.Text := EditIzmerenie.Text;
    end;
  if CBCreate.ItemIndex = 2 then
    begin
      SQLQuery3.SQL.Add('SELECT Designation FROM Designation WHERE Designation = "' + EEditIzmerenie.Text + '"');
      SQLQuery3.Open;
      ClientDataSet3.Active := true;
      EditFoundMaxID.Text := VarToStr(SQLQuery3.FieldValues['Designation']);
      if EditFoundMaxID.Text <> EEditIzmerenie.Text then
      begin
        ShowMessage('����� ������������ �� ����������.');
        Exit;
      end;
      EditFoundMaxID.Text := '';

      ClientDataSet3.Active := false;
      SQLQuery3.Close;
      SQLQuery3.SQL.Clear;
      SQLQuery3.SQL.Add('UPDATE Designation SET  Designation = "' + EditIzmerenie.Text + '" ');
      SQLQuery3.SQL.Add('WHERE Designation = "' + EEditIzmerenie.Text + '"');
      for i := 0 to DBCBIzmerenie.Items.Count do
        if EEditIzmerenie.Text = DBCBIzmerenie.Items.Strings[i-1] then
        begin
          DBCBIzmerenie.Items.Delete(i-1);
          ShMB := false;
          break;
        end
        else
          ShMB := true;
      if ShMB = true then
      begin
        ShowMessage('������ �������� ���.');
        exit;
      end;
      for i := 0 to DBCBIzmerenie.Items.Count do
        if EditIzmerenie.Text <> DBCBNaznach.Items.Strings[i-1] then
          begin
            DBCBIzmerenie.Items.Add(EditIzmerenie.Text);
            Break;
          end;
      CBIzmerenie.Refresh;
      DBCBIzmerenie.Refresh;
      EEditIzmerenie.Text := EditIzmerenie.Text;
    end;
  SQLQuery3.ExecSQL;
end;

procedure TForm1.BtnEdHandCharacClick(Sender: TObject);
begin
  if usCaptionC = false then
    begin
      BtnEdHandCharac.Caption := '������� ��������������';
      usCaptionC := true;
      DBEditSymbol.ReadOnly := false;

      DBEditV_Min.ReadOnly := false;

      DBEditV_Max.ReadOnly := false;

      DBCBIzmerenie.ReadOnly := false;
    end
  else
    begin
      BtnEdHandCharac.Caption := '������������� �������';
      usCaptionC := false;
      DBEditSymbol.ReadOnly := true;

      DBEditV_Min.ReadOnly := true;

      DBEditV_Max.ReadOnly := true;

      DBCBIzmerenie.ReadOnly := true;
    end;
end;

procedure TForm1.BtnEdHandZapisClick(Sender: TObject);
begin
  if usCaption = false then
    begin
      BtnEdHandZapis.Caption := '������� ��������������';
      usCaption := true;
      DBEditOboznach.ReadOnly := false;

      DBEditName.ReadOnly := false;

      DBCBNaznach.ReadOnly := false;

      DBCBSreda.ReadOnly := false;
    end
  else
    begin
      BtnEdHandZapis.Caption := '������������� �������';
      usCaption := false;
      DBEditOboznach.ReadOnly := true;
      DBEditOboznach.DataField := 'Designation';
      DBEditOboznach.DataSource := DataSource1;
      DBEditName.ReadOnly := true;
      DBEditName.DataField := 'Name';
      DBEditName.DataSource := DataSource1;
      DBCBNaznach.ReadOnly := true;
      DBCBNaznach.DataField := 'Appointment';
      DBCBNaznach.DataSource := DataSource1;
      DBCBSreda.ReadOnly := true;
      DBCBSreda.DataField := 'Appointment_1';
      DBCBSreda.DataSource := DataSource1;
    end;
end;

procedure TForm1.BtnEdZapisClick(Sender: TObject);
Var i, bufID : integer;
ShMB : boolean;
bufNaznach, bufSreda, bufOboznach, bufName: string;
bufDBOboznach : string;
begin
  if (EditOboznach.Text = '') or (EditOboznach.Text = '�����������') then
    begin
      ShowMessage('������� ����� �����������.');
      exit;
    end;
  if (DBEditOboznach.Text = '') then
    begin
      ShowMessage('������� ���������� �����������.');
      exit;
    end;
  ClientDataSet3.Active := false;
   SQLQuery3.Close;
    SQLQuery3.SQL.Clear;
     SQLQuery3.SQL.Add('SELECT Designation FROM Drawing WHERE Designation = "' + DBEditOboznach.Text + '"');
      SQLQuery3.Open;
       ClientDataSet3.Active := true;
  bufOboznach := VarToStr(SQLQuery3.FieldValues['Designation']);
    if bufOboznach <> DBEditOboznach.Text then
      begin
        ShowMessage('���������� ����������� �� ����������.');
        Exit;
      end;
  ClientDataSet3.Active := false;
   SQLQuery3.Close;
    SQLQuery3.SQL.Clear;
     SQLQuery3.SQL.Add('SELECT Designation FROM Drawing WHERE Designation = "' + EditOboznach.Text + '"');
      SQLQuery3.Open;
       ClientDataSet3.Active := true;
  bufOboznach := VarToStr(SQLQuery3.FieldValues['Designation']);
  if (bufOboznach = EditOboznach.Text) and (EditOboznach.Text <> DBEditOboznach.Text) then
    begin
      ShowMessage('����� ����������� ��� ����������.');
      Exit;
    end;

  if (EditNaim.Text = '') or (EditNaim.Text = '������������') then
    begin
      ShowMessage('������� ����� ������������.');
      exit;
    end;
  if (DBEditName.Text = '') then
    begin
      ShowMessage('������� ���������� ������������.');
      exit;
    end;

  ClientDataSet3.Active := false;
   SQLQuery3.Close;
    SQLQuery3.SQL.Clear;
     SQLQuery3.SQL.Add('SELECT Name FROM Drawing WHERE Name = "' + DBEditName.Text + '"');
      SQLQuery3.Open;
       ClientDataSet3.Active := true;
  bufName := VarToStr(SQLQuery3.FieldValues['Name']);
  if bufName <> DBEditName.Text then
    begin
      ShowMessage('���������� ������������ �� ����������.');
      Exit;
    end;

  if (CBNaznach.Text = '') then
    begin
      ShowMessage('�������� ����� ����������.');
      exit;
    end;

  if (CBSreda.Text = '') then
    begin
      ShowMessage('�������� ����� �����.');
      exit;
    end;

  ClientDataSet3.Active := false;
   SQLQuery3.Close;
    SQLQuery3.SQL.Clear;
     SQLQuery3.SQL.Add('SELECT ID FROM Conditions WHERE Appointment = "' + DBCBNaznach.Text + '"');
      SQLQuery3.Open;
       ClientDataSet3.Active := true;
  bufNaznach := VarToStr(SQLQuery3.FieldValues['ID']);

  ClientDataSet3.Active := false;
   SQLQuery3.Close;
    SQLQuery3.SQL.Clear;
     SQLQuery3.SQL.Add('SELECT ID FROM Environment WHERE Appointment = "' + DBCBSreda.Text + '"');
      SQLQuery3.Open;
       ClientDataSet3.Active := true;
  bufSreda := VarToStr(SQLQuery3.FieldValues['ID']);

  ClientDataSet3.Active := false;
   SQLQuery3.Close;
    SQLQuery3.SQL.Clear;
     SQLQuery3.SQL.Add('SELECT ID FROM Drawing WHERE Designation = "' + DBEditOboznach.Text + '" AND Name = "' + DBEditName.Text + '" ');
      SQLQuery3.SQL.Add('And ID_Environment = ' + bufSreda + ' AND ID_Conditions = ' + bufNaznach);
       SQLQuery3.Open;
        ClientDataSet3.Active := true;
  EditFoundMaxID.Text := '';

  bufID := 0;
  EditFoundMaxID.Text := IntToStr(SQLQuery3.FieldValues['ID']);
  if EditFoundMaxID.Text = '' then
    begin
      ShowMessage('������ �� ������.');
      exit;
    end;

  ClientDataSet3.Active := false;
   SQLQuery3.Close;
    SQLQuery3.SQL.Clear;
     SQLQuery3.SQL.Add('SELECT ID FROM Conditions WHERE Appointment = "' + CBNaznach.Text + '"');
      SQLQuery3.Open;
       ClientDataSet3.Active := true;
  bufNaznach := VarToStr(SQLQuery3.FieldValues['ID']);

  ClientDataSet3.Active := false;
   SQLQuery3.Close;
    SQLQuery3.SQL.Clear;
     SQLQuery3.SQL.Add('SELECT ID FROM Environment WHERE Appointment = "' + CBSreda.Text + '"');
      SQLQuery3.Open;
       ClientDataSet3.Active := true;
  bufSreda := VarToStr(SQLQuery3.FieldValues['ID']);

  SQLQuery3.Close;
   SQLQuery3.SQL.Clear;
    SQLQuery3.SQL.Add('UPDATE Drawing SET Designation = "' + EditOboznach.Text + '", Name = "' + EditNaim.Text + '", ');
     SQLQuery3.SQL.Add('ID_Environment = ' + bufSreda + ', ID_Conditions = ' + bufNaznach);
      SQLQuery3.SQL.Add('WHERE ID = ' + EditFoundMaxID.Text);
       SQLQuery3.ExecSQL;

  N6Click(Self);
  DBGrid1.DataSource.DataSet.Locate('ID', EditFoundMaxID.Text, [loCaseInsensitive, loPartialKey]);
end;

procedure TForm1.BtnDelZapisCharacClick(Sender: TObject);
Var bufDesign : string;
begin
  if (EditOboznach.Text = '') or (EditOboznach.Text = '�����������') then
    begin
      ShowMessage('������� ��������� �����������.');
      exit;
    end;

  ClientDataSet3.Active := false;
  SQLQuery3.Close;
  SQLQuery3.SQL.Clear;
  SQLQuery3.SQL.Add('SELECT Designation FROM Drawing WHERE Designation = "' + EditOboznach.Text + '"');
  SQLQuery3.Open;
  ClientDataSet3.Active := true;
  EditFoundMaxID.Text := VarToStr(SQLQuery3.FieldValues['Designation']);
    if EditFoundMaxID.Text <> EditOboznach.Text then
      begin
        ShowMessage('����� ������ �� ����������.');
        Exit;
      end;
  EditFoundMaxID.Text := '';

  ClientDataSet3.Active := false;
  SQLQuery3.Close;
  SQLQuery3.SQL.Clear;
  SQLQuery3.SQL.Add('SELECT ID_Characteristics FROM Drawing WHERE Designation = "' + EditOboznach.Text + '"');
  SQLQuery3.Open;
  ClientDataSet3.Active := true;
  EditFoundMaxID.Text := VarToStr(SQLQuery3.FieldValues['ID_Characteristics']);
        SQLQuery3.SQL.Clear;
        SQLQuery3.SQL.Add('DELETE FROM Characteristics WHERE ID = ' + EditFoundMaxID.Text);
        SQLQuery3.ExecSQL;
  EditFoundMaxID.Text := '';

  SQLQuery3.SQL.Clear;
  SQLQuery3.SQL.Add('DELETE FROM Drawing WHERE Designation = "' + EditOboznach.Text + '" ');
  SQLQuery3.ExecSQL;

  N6Click(Self);
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
  acropdf1.LoadFile('DONTEXISTS.pdf');
  DBGrid1.SetFocus;
end;

procedure TForm1.CBCAllClick(Sender: TObject);
begin
  ClientDataSet1.Active := false;
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('SELECT Drawing.ID, Drawing.Designation, Drawing.Name, Conditions.Appointment, Environment.Appointment, Image FROM Drawing, Conditions, Environment ');
  SQLQuery1.SQL.Add('WHERE Drawing.ID_Conditions = Conditions.ID AND Drawing.ID_Environment = Environment.ID ORDER BY Designation ASC');
  SQLQuery1.Open;
  ClientDataSet1.Active := true;
  DBGrid1.SetFocus;
end;

procedure TForm1.CBFSymbolClick(Sender: TObject);
begin
  StaticText1.Visible := false;
end;

procedure TForm1.CBIzmerenieClick(Sender: TObject);
begin
  StaticText4.Visible := false;
end;

procedure TForm1.CBNaznachClick(Sender: TObject);
begin
  StaticText3.Visible := false;
end;

procedure TForm1.CBSredaClick(Sender: TObject);
begin
  StaticText2.Visible := false;
end;

procedure TForm1.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  if FileExists('temp\temp.pdf') then
    DeleteFile('temp\temp.pdf');
  if FileExists('temp\buf.pdf') then
    DeleteFile('temp\buf.pdf');
  Ref := AcroPdf1.ControlInterface._AddRef;
  AcroPdf1.Src := '';
  FreeAndNil(AcroPdf1);
  Ref := FormPDF.AcroPdf1.ControlInterface._AddRef;
  FormPDF.AcroPdf1.Src := '';
  FreeAndNil(FormPDF.AcroPdf1);
  Form2.Close;
  FormPDF.Close;
end;

procedure TForm1.FormCreate(Sender: TObject);
var
  I,II :Integer;
begin
  II := PageControl1.PageCount;
  If II > 0 then
  For I := 0 To II - 1 do
    PageControl1.Pages[I].TabVisible := False;
  PageControl1.ActivePageIndex := 0;
end;

procedure TForm1.FormKeyPress(Sender: TObject; var Key: Char);
Var PicWithAPDF, B: Tmemorystream;
begin
  if key = #13 then
    begin
      if FileExists('temp\temp.pdf') then
        DeleteFile('temp\temp.pdf');
      ID_s := DBGrid1.Fields[0].Value;
      ClientDataSet3.Active := false;
       SQLQuery3.Close;
        SQLQuery3.SQL.Clear;
         SQLQuery3.SQL.Add('SELECT * FROM Drawing WHERE ID = ' + ID_s);
          SQLQuery3.Open;
           ClientDataSet3.Active := true;
      PicWithAPDF := Tmemorystream.Create;
      TBLOBField(Form1.SQLQuery3.FieldByName('Image')).SaveToStream(PicWithAPDF);
      PicWithAPDF.Position := 0;
      PicWithAPDF.SaveToFile('temp\temp.pdf');
      FreeAndNil(PicWithAPDF);
      acropdf1.LoadFile('temp\temp.pdf');
    end;
end;

procedure TForm1.FormShow(Sender: TObject);
begin
  SetWindowLong(AcroPDF1.Handle, GWL_STYLE, GetWindowLong(AcroPDF1.Handle, GWL_STYLE) or WS_THICKFRAME);
  SetWindowLong(AcroPDF1.Handle, GWL_EXSTYLE, GetWindowLong(AcroPDF1.Handle, GWL_EXSTYLE) and not WS_EX_CLIENTEDGE);
end;

procedure TForm1.HelperClick(Sender: TObject);
begin
  FormHelp.Show;
end;

procedure TForm1.MySiteClick(Sender: TObject);
begin
  ShellExecute (Form1.Handle, nil, 'iexplore', 'https://projectstructuraldrawinghelper.nethouse.ru/', nil, SW_RESTORE);
end;

procedure TForm1.ImgAddClick(Sender: TObject);
begin
  DbGrid1.DataSource.DataSet.Insert;
end;

procedure TForm1.MMAddClick(Sender: TObject);
begin
  CBCreate.Visible := true;
  EditIzmerenie.Visible := true;
  BtnSaveEditor.Visible := true;
  Label1.Visible := true;
  LabelZapis.Visible := true;
  EditOboznach.Visible := true;
  EditNaim.Visible := true;
  StaticText3.Visible := true;
  CBNaznach.Visible := true;
  StaticText2.Visible := true;
  CBSreda.Visible := true;
  BtnSaveAddZapis.Visible := true;
  LabelCharac.Visible := true;
  BtnAddCharac.Visible := true;
  StaticText4.Visible := true;
  CBIzmerenie.Visible := true;
  EditV_Max.Visible := true;
  EditV_Min.Visible := true;
  EditSymbol.Visible := true;
  BtnAddPDF.Visible := true;

  EEditIzmerenie.Visible := false;
  BtnEdEditor.Visible := false;
  DBEditOboznach.Visible := false;
  DBEditName.Visible := false;
  DBCBNaznach.Visible := false;
  DBCBSreda.Visible := false;
  BtnEdZapis.Visible := false;
  BtnEdCharac.Visible := false;
  DBCBIzmerenie.Visible := false;
  DBEditV_Max.Visible := false;
  DBEditV_Min.Visible := false;
  DBEditSymbol.Visible := false;
  BtnEdHandZapis.Visible := false;
  BtnEdHandCharac.Visible := false;
  BtnDelEditor.Visible := false;
  BtnDelZapisCharac.Visible := false;
  BtnDelCharac.Visible := false;
  BtnDelPDF.Visible := false;
  ClientHeight := 685;
end;

procedure TForm1.MMEditClick(Sender: TObject);
begin
  DBGrid2.Options := DBGrid2.Options + [dgIndicator];
  CBCreate.Visible := true;
  EditIzmerenie.Visible := true;
  BtnSaveEditor.Visible := true;
  Label1.Visible := true;
  LabelZapis.Visible := true;
  EditOboznach.Visible := true;
  EditNaim.Visible := true;
  StaticText3.Visible := true;
  CBNaznach.Visible := true;
  StaticText2.Visible := true;
  CBSreda.Visible := true;
  BtnSaveAddZapis.Visible := true;
  LabelCharac.Visible := true;
  BtnAddCharac.Visible := true;
  StaticText4.Visible := true;
  CBIzmerenie.Visible := true;
  EditV_Max.Visible := true;
  EditV_Min.Visible := true;
  EditSymbol.Visible := true;
  EEditIzmerenie.Visible := true;
  BtnEdEditor.Visible := true;
  DBEditOboznach.Visible := true;
  DBEditName.Visible := true;
  DBCBNaznach.Visible := true;
  DBCBSreda.Visible := true;
  BtnEdZapis.Visible := true;
  BtnEdCharac.Visible := true;
  DBCBIzmerenie.Visible := true;
  DBEditV_Max.Visible := true;
  DBEditV_Min.Visible := true;
  DBEditSymbol.Visible := true;
  BtnEdHandZapis.Visible := true;
  BtnEdHandCharac.Visible := true;
  BtnAddPDF.Visible := true;
  BtnSaveEditor.Visible := false;
  BtnDelEditor.Visible := false;
  BtnSaveAddZapis.Visible := false;
  BtnDelZapisCharac.Visible := false;
  BtnAddCharac.Visible := false;
  BtnDelCharac.Visible := false;
  BtnDelPDF.Visible := false;
  ClientHeight := 685;
end;

procedure TForm1.N3Click(Sender: TObject);
begin
  StaticText1.Visible := true;
  SQLFound := true;
  CBFOperMin.Visible := true;
  CBFOperMax.Visible := true;
  EditFV_Min.Visible := true;
  EditFV_Max.Visible := true;
  CBFSymbol.Visible := true;
  BtnFClear.Visible := true;
  BtnFound.Visible := true;
  ClientHeight := 650;
end;

procedure TForm1.N5Click(Sender: TObject);
begin
  StaticText1.Visible := false;
  CBFSymbol.Visible := false;
  CBFOperMin.Visible := false;
  CBFOperMax.Visible := false;
  EditFV_Min.Visible := false;
  EditFV_Max.Visible := false;
  BtnFound.Visible := false;
  BtnFClear.Visible := false;
  EditFV_Max.Visible := false;
  EditFV_Min.Visible := false;
  ClientHeight := 590;
end;

procedure TForm1.N6Click(Sender: TObject);
begin
  ClientDataSet1.Active := false;
   SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
     SQLQuery1.SQL.Add('SELECT DISTINCT Drawing.ID, Drawing.Designation, Drawing.Name, Conditions.Appointment, Environment.Appointment, Image FROM Drawing, Conditions, Environment, Characteristics');
      SQLQuery1.SQL.Add(' WHERE Drawing.ID_Conditions  =  Conditions.ID AND Drawing.ID_Environment = Environment.ID AND drawing.ID_Characteristics = Characteristics.ID');
       SQLQuery1.Open;
        ClientDataSet1.Active := true;

  ClientDataSet2.Active := false;
   SQLQuery2.Close;
    SQLQuery2.SQL.Clear;
     SQLQuery2.SQL.Add('SELECT Characteristics.Id, Characteristics.Symbol, Characteristics.V_min, Characteristics.V_max, Designation.Designation');
      SQLQuery2.SQL.Add(' FROM Characteristics, Designation WHERE Characteristics.ID_Designation = Designation.ID');
       SQLQuery2.Open;
        ClientDataSet2.Active := true;

  DataSource1.DataSet.Active := false;
   DataSource1.DataSet.Active := true;
    DBGrid1.Refresh;
  DataSource2.DataSet.Active := false;
   DataSource2.DataSet.Active := true;
    DBGrid2.Refresh;
end;

procedure TForm1.MMDelClick(Sender: TObject);
begin
  CBCreate.Visible := true;
  EditIzmerenie.Visible := true;
  BtnDelEditor.Visible := true;
  Label1.Visible := true;
  LabelZapis.Visible := true;
  EditOboznach.Visible := true;
  BtnDelZapisCharac.Visible := true;
  LabelCharac.Visible := true;
  BtnDelCharac.Visible := true;
  StaticText4.Visible := false;
  CBIzmerenie.Visible := true;
  EditV_Max.Visible := true;
  EditV_Min.Visible := true;
  EditSymbol.Visible := true;
  BtnDelPDF.Visible := true;

  EEditIzmerenie.Visible := false;
  BtnEdEditor.Visible := false;
  DBEditOboznach.Visible := false;
  DBEditName.Visible := false;
  DBCBNaznach.Visible := false;
  DBCBSreda.Visible := false;
  BtnEdZapis.Visible := false;
  BtnEdCharac.Visible := false;
  DBCBIzmerenie.Visible := false;
  DBEditV_Max.Visible := false;
  DBEditV_Min.Visible := false;
  DBEditSymbol.Visible := false;
  BtnEdHandZapis.Visible := false;
  BtnEdHandCharac.Visible := false;
  BtnSaveEditor.Visible := false;
  BtnSaveAddZapis.Visible := false;
  BtnAddCharac.Visible := false;
  BtnAddPDF.Visible := false;
  CBSreda.Visible := false;
  StaticText3.Visible := false;
  StaticText2.Visible := false;
  CBNaznach.Visible := false;
  EditNaim.Visible := false;
  ClientHeight := 685;
end;

procedure TForm1.MMAllClick(Sender: TObject);
begin
  DBGrid2.Options := DBGrid2.Options + [dgIndicator];
  CBCreate.Visible := true;
  EditIzmerenie.Visible := true;
  BtnSaveEditor.Visible := true;
  Label1.Visible := true;
  LabelZapis.Visible := true;
  EditOboznach.Visible := true;
  EditNaim.Visible := true;
  StaticText3.Visible := true;
  CBNaznach.Visible := true;
  StaticText2.Visible := true;
  CBSreda.Visible := true;
  BtnSaveAddZapis.Visible := true;
  LabelCharac.Visible := true;
  BtnAddCharac.Visible := true;
  StaticText4.Visible := true;
  CBIzmerenie.Visible := true;
  EditV_Max.Visible := true;
  EditV_Min.Visible := true;
  EditSymbol.Visible := true;
  EEditIzmerenie.Visible := true;
  BtnEdEditor.Visible := true;
  DBEditOboznach.Visible := true;
  DBEditName.Visible := true;
  DBCBNaznach.Visible := true;
  DBCBSreda.Visible := true;
  BtnEdZapis.Visible := true;
  BtnEdCharac.Visible := true;
  DBCBIzmerenie.Visible := true;
  DBEditV_Max.Visible := true;
  DBEditV_Min.Visible := true;
  DBEditSymbol.Visible := true;
  BtnEdHandZapis.Visible := true;
  BtnEdHandCharac.Visible := true;
  BtnSaveEditor.Visible := true;
  BtnDelEditor.Visible := true;
  BtnSaveAddZapis.Visible := true;
  BtnDelZapisCharac.Visible := true;
  BtnAddCharac.Visible := true;
  BtnDelCharac.Visible := true;
  BtnAddPDF.Visible := true;
  BtnDelPDF.Visible := true;
  ClientHeight := 685;
end;

procedure TForm1.MMClearClick(Sender: TObject);
begin
  DBGrid2.Options := DBGrid2.Options - [dgIndicator];
  CBCreate.Visible := false;
  EditIzmerenie.Visible := false;
  BtnSaveEditor.Visible := false;
  Label1.Visible := false;
  LabelZapis.Visible := false;
  EditOboznach.Visible := false;
  EditNaim.Visible := false;
  StaticText3.Visible := false;
  CBNaznach.Visible := false;
  StaticText2.Visible := false;
  CBSreda.Visible := false;
  BtnSaveAddZapis.Visible := false;
  LabelCharac.Visible := false;
  BtnAddCharac.Visible := false;
  StaticText4.Visible := false;
  CBIzmerenie.Visible := false;
  EditV_Max.Visible := false;
  EditV_Min.Visible := false;
  EditSymbol.Visible := false;
  EEditIzmerenie.Visible := false;
  BtnEdEditor.Visible := false;
  DBEditOboznach.Visible := false;
  DBEditName.Visible := false;
  DBCBNaznach.Visible := false;
  DBCBSreda.Visible := false;
  BtnEdZapis.Visible := false;
  BtnEdCharac.Visible := false;
  DBCBIzmerenie.Visible := false;
  DBEditV_Max.Visible := false;
  DBEditV_Min.Visible := false;
  DBEditSymbol.Visible := false;
  BtnEdHandZapis.Visible := false;
  BtnEdHandCharac.Visible := false;
  BtnSaveEditor.Visible := false;
  BtnDelEditor.Visible := false;
  BtnSaveAddZapis.Visible := false;
  BtnDelZapisCharac.Visible := false;
  BtnAddCharac.Visible := false;
  BtnDelCharac.Visible := false;
  BtnAddPDF.Visible := false;
  BtnDelPDF.Visible := false;
  ClientHeight := 590;
end;

end.

