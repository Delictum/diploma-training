unit Unit5;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Data.FMTBcd, DBXMySQL, Vcl.DBCtrls,
  Vcl.StdCtrls, Data.DB, Data.SqlExpr, Datasnap.Provider, Datasnap.DBClient,
  Vcl.Mask;

type
  TForm5 = class(TForm)
    DBEdit1: TDBEdit;
    DBEdit2: TDBEdit;
    DBEdit3: TDBEdit;
    Edit4: TEdit;
    Memo1: TMemo;
    Button1: TButton;
    DataSource1: TDataSource;
    ClientDataSet1: TClientDataSet;
    DataSetProvider1: TDataSetProvider;
    SQLQuery1: TSQLQuery;
    SQLConnection1: TSQLConnection;
    DBComboBox1: TDBComboBox;
    SQLConnection2: TSQLConnection;
    SQLQuery2: TSQLQuery;
    DataSetProvider2: TDataSetProvider;
    ClientDataSet2: TClientDataSet;
    DataSource2: TDataSource;
    SQLQuery3: TSQLQuery;
    DataSource3: TDataSource;
    ClientDataSet3: TClientDataSet;
    DataSetProvider3: TDataSetProvider;
    SQLConnection3: TSQLConnection;
    SQLQuery4: TSQLQuery;
    DataSource4: TDataSource;
    ClientDataSet4: TClientDataSet;
    DataSetProvider4: TDataSetProvider;
    SQLConnection4: TSQLConnection;
    DBLCB1: TDBLookupComboBox;
    DBLCB2: TDBLookupComboBox;
    DBLCB3: TDBLookupComboBox;
    Button2: TButton;
    Button3: TButton;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form5: TForm5;
  bufID, bufName1, bufName2, bufName3, bufName4 : string;
  ID : integer;

implementation

{$R *.dfm}

uses Unit1;

procedure TForm5.Button1Click(Sender: TObject);
var i : integer;
begin
  ClientDataSet1.Active := false;
       SQLQuery1.Close;
        SQLQuery1.SQL.Clear;
         SQLQuery1.SQL.Add('SELECT Dinozavr FROM Dinozavr_Main WHERE Dinozavr = "' + Edit4.Text + '"');
          SQLQuery1.Open;
           ClientDataSet1.Active := true;
      bufName1 := VarToStr(SQLQuery1.FieldValues['Dinozavr']);
      if bufName1 = DBLCB3.Text then
        begin
          ShowMessage('�������� ��� ����������.');
          exit;
        end;

      ClientDataSet1.Active := false;
       SQLQuery1.Close;
        SQLQuery1.SQL.Clear;
         SQLQuery1.SQL.Add('SELECT ID FROM Eda WHERE Eda = "' + DBLCB1.Text + '"');
          SQLQuery1.Open;
           ClientDataSet1.Active := true;
      bufName2 := VarToStr(SQLQuery1.FieldValues['ID']);

      ClientDataSet1.Active := false;
       SQLQuery1.Close;
        SQLQuery1.SQL.Clear;
         SQLQuery1.SQL.Add('SELECT ID FROM Otryd WHERE Otryd = "' + DBLCB2.Text + '"');
          SQLQuery1.Open;
           ClientDataSet1.Active := true;
      bufName3 := VarToStr(SQLQuery1.FieldValues['ID']);

      ClientDataSet1.Active := false;
       SQLQuery1.Close;
        SQLQuery1.SQL.Clear;
         SQLQuery1.SQL.Add('SELECT ID FROM Period WHERE Period = "' + DBLCB3.Text + '"');
          SQLQuery1.Open;
           ClientDataSet1.Active := true;
      bufName4 := VarToStr(SQLQuery1.FieldValues['ID']);

      ClientDataSet1.Active := false;
        SQLQuery1.Close;
         SQLQuery1.SQL.Clear;
          SQLQuery1.SQL.Add('SELECT MAX(ID) AS ID FROM Dinozavr_Main');
           SQLQuery1.Open;
            ClientDataSet1.Active := true;
      BufID := IntToStr(SQLQuery1.FieldValues['ID']);
      ID := StrToInt(BufID) + 1;
      SQLQuery1.Close;
       SQLQuery1.SQL.Clear;
        SQLQuery1.SQL.Add('INSERT INTO Dinozavr_Main(ID, ID_Eda, ID_Otryd, ID_Period, Dinozavr, Text) VALUES (');
         SQLQuery1.SQL.Add(IntToStr(ID) + ', ' + bufName2 + ', ' + bufName3 + ', ' + bufName4 + ', "' + Edit4.Text + '", "');
         for I := 0 to Memo1.Lines.Count do
        SQLQuery1.SQL.Add(Memo1.Lines[i]);
        SQLQuery1.SQL.Add('")');
          SQLQuery1.ExecSQL;

      FormDinozavr.ClientDataSet1.Active := false;
       FormDinozavr.SQLQuery1.Close;
        FormDinozavr.SQLQuery1.SQL.Clear;
         FormDinozavr.SQLQuery1.SQL.Add('SELECT Dinozavr_Main.ID, Eda, Otryd, Period, Dinozavr, Text FROM Dinozavr_Main, Period, Otryd, Eda WHERE Dinozavr_Main.ID_Eda = Eda.ID AND Dinozavr_Main.ID_Otryd = Otryd.ID AND Dinozavr_Main.ID_Period = Period.ID');
          FormDinozavr.SQLQuery1.Open;
           FormDinozavr.ClientDataSet1.Active := true;
      ShowMessage('�������� ������� ��������.');
end;

procedure TForm5.Button2Click(Sender: TObject);
begin

  ClientDataSet1.Active := false;
        SQLQuery1.Close;
         SQLQuery1.SQL.Clear;
          SQLQuery1.SQL.Add('SELECT Dinozavr FROM Dinozavr_Main WHERE Dinozavr = "' + Edit4.Text + '"');
           SQLQuery1.Open;
            ClientDataSet1.Active := true;
      BufID := VarToStr(SQLQuery1.FieldValues['Dinozavr']);

      if bufID <> Edit4.Text then
        begin
          ShowMessage('��������� �� ����������.');
          exit;
        end;

      SQLQuery1.Close;
       SQLQuery1.SQL.Clear;
        SQLQuery1.SQL.Add('DELETE FROM Dinozavr_Main WHERE Dinozavr = "' + Edit4.Text + '"');
          SQLQuery1.ExecSQL;

  FormDinozavr.ClientDataSet1.Active := false;
       FormDinozavr.SQLQuery1.Close;
        FormDinozavr.SQLQuery1.SQL.Clear;
         FormDinozavr.SQLQuery1.SQL.Add('SELECT Dinozavr_Main.ID, Eda, Otryd, Period, Dinozavr, Text FROM Dinozavr_Main, Period, Otryd, Eda WHERE Dinozavr_Main.ID_Eda = Eda.ID AND Dinozavr_Main.ID_Otryd = Otryd.ID AND Dinozavr_Main.ID_Period = Period.ID');
          FormDinozavr.SQLQuery1.Open;
           FormDinozavr.ClientDataSet1.Active := true;

  ShowMessage('�������� ������� ������.');
end;

procedure TForm5.Button3Click(Sender: TObject);
var i : integer;
begin
   ClientDataSet1.Active := false;
        SQLQuery1.Close;
         SQLQuery1.SQL.Clear;
          SQLQuery1.SQL.Add('SELECT Dinozavr FROM Dinozavr_Main WHERE Dinozavr = "' + DBEdit1.Text + '"');
           SQLQuery1.Open;
            ClientDataSet1.Active := true;
      BufID := VarToStr(SQLQuery1.FieldValues['Dinozavr']);

      if bufID <> DBEdit1.Text then
        begin
          ShowMessage('��������� �� ����������.');
          exit;
        end;

   ClientDataSet1.Active := false;
       SQLQuery1.Close;
        SQLQuery1.SQL.Clear;
         SQLQuery1.SQL.Add('SELECT ID FROM Eda WHERE Eda = "' + DBLCB1.Text + '"');
          SQLQuery1.Open;
           ClientDataSet1.Active := true;
      bufName2 := VarToStr(SQLQuery1.FieldValues['ID']);

      ClientDataSet1.Active := false;
       SQLQuery1.Close;
        SQLQuery1.SQL.Clear;
         SQLQuery1.SQL.Add('SELECT ID FROM Otryd WHERE Otryd = "' + DBLCB2.Text + '"');
          SQLQuery1.Open;
           ClientDataSet1.Active := true;
      bufName3 := VarToStr(SQLQuery1.FieldValues['ID']);

      ClientDataSet1.Active := false;
       SQLQuery1.Close;
        SQLQuery1.SQL.Clear;
         SQLQuery1.SQL.Add('SELECT ID FROM Period WHERE Period = "' + DBLCB3.Text + '"');
          SQLQuery1.Open;
           ClientDataSet1.Active := true;
      bufName4 := VarToStr(SQLQuery1.FieldValues['ID']);

      SQLQuery1.Close;
       SQLQuery1.SQL.Clear;
        SQLQuery1.SQL.Add('UPDATE Dinozavr_Main Set ID_Eda = ' + bufName2 + ', ID_Otryd = ' + bufName3 + ', ID_Period = ' + bufName4 + ' , Dinozavr = "' + Edit4.Text + '", Text = "');
        for I := 0 to Memo1.Lines.Count do
        SQLQuery1.SQL.Add(Memo1.Lines[i]);
        SQLQuery1.SQL.Add('" WHERE Dinozavr = "' + DBEdit1.Text + '"');
          SQLQuery1.ExecSQL;


   FormDinozavr.ClientDataSet1.Active := false;
       FormDinozavr.SQLQuery1.Close;
        FormDinozavr.SQLQuery1.SQL.Clear;
         FormDinozavr.SQLQuery1.SQL.Add('SELECT Dinozavr_Main.ID, Eda, Otryd, Period, Dinozavr, Text FROM Dinozavr_Main, Period, Otryd, Eda WHERE Dinozavr_Main.ID_Eda = Eda.ID AND Dinozavr_Main.ID_Otryd = Otryd.ID AND Dinozavr_Main.ID_Period = Period.ID');
          FormDinozavr.SQLQuery1.Open;
           FormDinozavr.ClientDataSet1.Active := true;

  ShowMessage('�������� ������� �������.');
end;

end.
