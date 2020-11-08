unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, DBXMySQL, Data.FMTBcd, Data.DB,
  Vcl.StdCtrls, Vcl.DBCtrls, Vcl.Grids, Vcl.DBGrids, Datasnap.DBClient,
  Datasnap.Provider, Data.SqlExpr, Vcl.Imaging.pngimage, Vcl.ExtCtrls, Jpeg,
  Vcl.Menus, ShellAPI;

type
  TFormDinozavr = class(TForm)
    SQLConnection1: TSQLConnection;
    SQLQuery1: TSQLQuery;
    DataSetProvider1: TDataSetProvider;
    ClientDataSet1: TClientDataSet;
    DataSource1: TDataSource;
    DBGrid1: TDBGrid;
    DBMemo1: TDBMemo;
    ComboBox1: TComboBox;
    ComboBox2: TComboBox;
    ComboBox3: TComboBox;
    ComboBox4: TComboBox;
    Image1: TImage;
    Image2: TImage;
    MainMenu1: TMainMenu;
    N1: TMenuItem;
    N4: TMenuItem;
    Helper1: TMenuItem;
    procedure ComboBox1Change(Sender: TObject);
    procedure ComboBox2Change(Sender: TObject);
    procedure ComboBox3Change(Sender: TObject);
    procedure ComboBox4Change(Sender: TObject);
    procedure Image1Click(Sender: TObject);
    procedure N4Click(Sender: TObject);
    procedure Helper1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  FormDinozavr: TFormDinozavr;

implementation

{$R *.dfm}

uses Unit3, Unit2;

procedure TFormDinozavr.ComboBox1Change(Sender: TObject);
begin
  case ComboBox1.ItemIndex of
    0:
      begin
        ClientDataSet1.Active := false;
         SQLQuery1.Close;
          SQLQuery1.SQL.Clear;
           SQLQuery1.SQL.Add('SELECT Dinozavr_Main.ID, Eda, Otryd, Period, Dinozavr, Text FROM ');
            SQLQuery1.SQL.Add('Dinozavr_Main, Period, Otryd, Eda, Epoha WHERE Dinozavr_Main.ID_Eda = Eda.ID ');
             SQLQuery1.SQL.Add('AND Dinozavr_Main.ID_Otryd = Otryd.ID AND Dinozavr_Main.ID_Period = Period.ID ');
              SQLQuery1.SQL.Add(' AND ID_Epoha = Epoha.ID AND Epoha.ID = 1 ');
               SQLQuery1.Open;
                ClientDataSet1.Active := true;
      end;
    1:
      begin
        ClientDataSet1.Active := false;
         SQLQuery1.Close;
          SQLQuery1.SQL.Clear;
           SQLQuery1.SQL.Add('SELECT Dinozavr_Main.ID, Eda, Otryd, Period, Dinozavr, Text FROM ');
            SQLQuery1.SQL.Add('Dinozavr_Main, Period, Otryd, Eda, Epoha WHERE Dinozavr_Main.ID_Eda = Eda.ID ');
             SQLQuery1.SQL.Add('AND Dinozavr_Main.ID_Otryd = Otryd.ID AND Dinozavr_Main.ID_Period = Period.ID ');
              SQLQuery1.SQL.Add(' AND ID_Epoha = Epoha.ID AND Epoha.ID = 2 ');
               SQLQuery1.Open;
                ClientDataSet1.Active := true;
      end;
    2:
      begin
        ClientDataSet1.Active := false;
         SQLQuery1.Close;
          SQLQuery1.SQL.Clear;
           SQLQuery1.SQL.Add('SELECT Dinozavr_Main.ID, Eda, Otryd, Period, Dinozavr, Text FROM ');
            SQLQuery1.SQL.Add('Dinozavr_Main, Period, Otryd, Eda, Epoha WHERE Dinozavr_Main.ID_Eda = Eda.ID ');
             SQLQuery1.SQL.Add('AND Dinozavr_Main.ID_Otryd = Otryd.ID AND Dinozavr_Main.ID_Period = Period.ID ');
              SQLQuery1.SQL.Add(' AND ID_Epoha = Epoha.ID AND Epoha.ID = 3 ');
               SQLQuery1.Open;
                ClientDataSet1.Active := true;
      end;
  end;




end;

procedure TFormDinozavr.ComboBox2Change(Sender: TObject);
begin
  case ComboBox2.ItemIndex of
    0:
      begin
        ClientDataSet1.Active := false;
         SQLQuery1.Close;
          SQLQuery1.SQL.Clear;
           SQLQuery1.SQL.Add('SELECT DISTINCT Dinozavr_Main.ID, Eda, Otryd, Period, Dinozavr, Text FROM ');
            SQLQuery1.SQL.Add('Dinozavr_Main, Period, Otryd, Eda, Epoha WHERE Dinozavr_Main.ID_Eda = Eda.ID ');
             SQLQuery1.SQL.Add('AND Dinozavr_Main.ID_Otryd = Otryd.ID AND Dinozavr_Main.ID_Period = Period.ID ');
              SQLQuery1.SQL.Add('AND Eda.ID = 1 ');
               SQLQuery1.Open;
                ClientDataSet1.Active := true;
      end;
    1:
      begin
        ClientDataSet1.Active := false;
         SQLQuery1.Close;
          SQLQuery1.SQL.Clear;
           SQLQuery1.SQL.Add('SELECT DISTINCT Dinozavr_Main.ID, Eda, Otryd, Period, Dinozavr, Text FROM ');
            SQLQuery1.SQL.Add('Dinozavr_Main, Period, Otryd, Eda, Epoha WHERE Dinozavr_Main.ID_Eda = Eda.ID ');
             SQLQuery1.SQL.Add('AND Dinozavr_Main.ID_Otryd = Otryd.ID AND Dinozavr_Main.ID_Period = Period.ID ');
              SQLQuery1.SQL.Add('AND Eda.ID = 2 ');
               SQLQuery1.Open;
                ClientDataSet1.Active := true;
      end;
    2:
      begin
        ClientDataSet1.Active := false;
         SQLQuery1.Close;
          SQLQuery1.SQL.Clear;
           SQLQuery1.SQL.Add('SELECT DISTINCT Dinozavr_Main.ID, Eda, Otryd, Period, Dinozavr, Text FROM ');
            SQLQuery1.SQL.Add('Dinozavr_Main, Period, Otryd, Eda, Epoha WHERE Dinozavr_Main.ID_Eda = Eda.ID ');
             SQLQuery1.SQL.Add('AND Dinozavr_Main.ID_Otryd = Otryd.ID AND Dinozavr_Main.ID_Period = Period.ID ');
              SQLQuery1.SQL.Add('AND Eda.ID = 3 ');
               SQLQuery1.Open;
                ClientDataSet1.Active := true;
      end;
  end;
end;

procedure TFormDinozavr.ComboBox3Change(Sender: TObject);
begin
  case ComboBox3.ItemIndex of
    0:
      begin
        ClientDataSet1.Active := false;
         SQLQuery1.Close;
          SQLQuery1.SQL.Clear;
           SQLQuery1.SQL.Add('SELECT DISTINCT Dinozavr_Main.ID, Eda, Otryd, Period, Dinozavr, Text FROM ');
            SQLQuery1.SQL.Add('Dinozavr_Main, Period, Otryd, Eda, Epoha WHERE Dinozavr_Main.ID_Eda = Eda.ID ');
             SQLQuery1.SQL.Add('AND Dinozavr_Main.ID_Otryd = Otryd.ID AND Dinozavr_Main.ID_Period = Period.ID ');
              SQLQuery1.SQL.Add('AND Otryd.ID = 1 ');
               SQLQuery1.Open;
                ClientDataSet1.Active := true;
      end;
    1:
      begin
        ClientDataSet1.Active := false;
         SQLQuery1.Close;
          SQLQuery1.SQL.Clear;
           SQLQuery1.SQL.Add('SELECT DISTINCT Dinozavr_Main.ID, Eda, Otryd, Period, Dinozavr, Text FROM ');
            SQLQuery1.SQL.Add('Dinozavr_Main, Period, Otryd, Eda, Epoha WHERE Dinozavr_Main.ID_Eda = Eda.ID ');
             SQLQuery1.SQL.Add('AND Dinozavr_Main.ID_Otryd = Otryd.ID AND Dinozavr_Main.ID_Period = Period.ID ');
              SQLQuery1.SQL.Add('AND Otryd.ID = 2 ');
               SQLQuery1.Open;
                ClientDataSet1.Active := true;
      end;
  end;
end;

procedure TFormDinozavr.ComboBox4Change(Sender: TObject);
begin
  case ComboBox4.ItemIndex of
    0:
      begin
        ClientDataSet1.Active := false;
         SQLQuery1.Close;
          SQLQuery1.SQL.Clear;
           SQLQuery1.SQL.Add('SELECT DISTINCT Dinozavr_Main.ID, Eda, Otryd, Period, Dinozavr, Text FROM ');
            SQLQuery1.SQL.Add('Dinozavr_Main, Period, Otryd, Eda, Epoha WHERE Dinozavr_Main.ID_Eda = Eda.ID ');
             SQLQuery1.SQL.Add('AND Dinozavr_Main.ID_Otryd = Otryd.ID AND Dinozavr_Main.ID_Period = Period.ID ');
              SQLQuery1.SQL.Add('AND Period.ID = 1');
               SQLQuery1.Open;
                ClientDataSet1.Active := true;
      end;
    1:
      begin
        ClientDataSet1.Active := false;
         SQLQuery1.Close;
          SQLQuery1.SQL.Clear;
           SQLQuery1.SQL.Add('SELECT DISTINCT Dinozavr_Main.ID, Eda, Otryd, Period, Dinozavr, Text FROM ');
            SQLQuery1.SQL.Add('Dinozavr_Main, Period, Otryd, Eda, Epoha WHERE Dinozavr_Main.ID_Eda = Eda.ID ');
             SQLQuery1.SQL.Add('AND Dinozavr_Main.ID_Otryd = Otryd.ID AND Dinozavr_Main.ID_Period = Period.ID ');
              SQLQuery1.SQL.Add('AND Period.ID = 2');
               SQLQuery1.Open;
                ClientDataSet1.Active := true;
      end;
    2:
      begin
        ClientDataSet1.Active := false;
         SQLQuery1.Close;
          SQLQuery1.SQL.Clear;
           SQLQuery1.SQL.Add('SELECT DISTINCT Dinozavr_Main.ID, Eda, Otryd, Period, Dinozavr, Text FROM ');
            SQLQuery1.SQL.Add('Dinozavr_Main, Period, Otryd, Eda, Epoha WHERE Dinozavr_Main.ID_Eda = Eda.ID ');
             SQLQuery1.SQL.Add('AND Dinozavr_Main.ID_Otryd = Otryd.ID AND Dinozavr_Main.ID_Period = Period.ID ');
              SQLQuery1.SQL.Add('AND Period.ID = 3');
               SQLQuery1.Open;
                ClientDataSet1.Active := true;
      end;
    3:
      begin
        ClientDataSet1.Active := false;
         SQLQuery1.Close;
          SQLQuery1.SQL.Clear;
           SQLQuery1.SQL.Add('SELECT DISTINCT Dinozavr_Main.ID, Eda, Otryd, Period, Dinozavr, Text FROM ');
            SQLQuery1.SQL.Add('Dinozavr_Main, Period, Otryd, Eda, Epoha WHERE Dinozavr_Main.ID_Eda = Eda.ID ');
             SQLQuery1.SQL.Add('AND Dinozavr_Main.ID_Otryd = Otryd.ID AND Dinozavr_Main.ID_Period = Period.ID ');
              SQLQuery1.SQL.Add('AND Period.ID = 4');
               SQLQuery1.Open;
                ClientDataSet1.Active := true;
      end;
    4:
      begin
        ClientDataSet1.Active := false;
         SQLQuery1.Close;
          SQLQuery1.SQL.Clear;
           SQLQuery1.SQL.Add('SELECT DISTINCT Dinozavr_Main.ID, Eda, Otryd, Period, Dinozavr, Text FROM ');
            SQLQuery1.SQL.Add('Dinozavr_Main, Period, Otryd, Eda, Epoha WHERE Dinozavr_Main.ID_Eda = Eda.ID ');
             SQLQuery1.SQL.Add('AND Dinozavr_Main.ID_Otryd = Otryd.ID AND Dinozavr_Main.ID_Period = Period.ID ');
              SQLQuery1.SQL.Add('AND Period.ID = 5');
               SQLQuery1.Open;
                ClientDataSet1.Active := true;
      end;
    5:
      begin
        ClientDataSet1.Active := false;
         SQLQuery1.Close;
          SQLQuery1.SQL.Clear;
           SQLQuery1.SQL.Add('SELECT DISTINCT Dinozavr_Main.ID, Eda, Otryd, Period, Dinozavr, Text FROM ');
            SQLQuery1.SQL.Add('Dinozavr_Main, Period, Otryd, Eda, Epoha WHERE Dinozavr_Main.ID_Eda = Eda.ID ');
             SQLQuery1.SQL.Add('AND Dinozavr_Main.ID_Otryd = Otryd.ID AND Dinozavr_Main.ID_Period = Period.ID ');
              SQLQuery1.SQL.Add('AND Period.ID = 6');
               SQLQuery1.Open;
                ClientDataSet1.Active := true;
      end;
    6:
      begin
        ClientDataSet1.Active := false;
         SQLQuery1.Close;
          SQLQuery1.SQL.Clear;
           SQLQuery1.SQL.Add('SELECT DISTINCT Dinozavr_Main.ID, Eda, Otryd, Period, Dinozavr, Text FROM ');
            SQLQuery1.SQL.Add('Dinozavr_Main, Period, Otryd, Eda, Epoha WHERE Dinozavr_Main.ID_Eda = Eda.ID ');
             SQLQuery1.SQL.Add('AND Dinozavr_Main.ID_Otryd = Otryd.ID AND Dinozavr_Main.ID_Period = Period.ID ');
              SQLQuery1.SQL.Add('AND Period.ID = 7');
               SQLQuery1.Open;
                ClientDataSet1.Active := true;
      end;
    7:
      begin
        ClientDataSet1.Active := false;
         SQLQuery1.Close;
          SQLQuery1.SQL.Clear;
           SQLQuery1.SQL.Add('SELECT DISTINCT Dinozavr_Main.ID, Eda, Otryd, Period, Dinozavr, Text FROM ');
            SQLQuery1.SQL.Add('Dinozavr_Main, Period, Otryd, Eda, Epoha WHERE Dinozavr_Main.ID_Eda = Eda.ID ');
             SQLQuery1.SQL.Add('AND Dinozavr_Main.ID_Otryd = Otryd.ID AND Dinozavr_Main.ID_Period = Period.ID ');
              SQLQuery1.SQL.Add('AND Period.ID = 8');
               SQLQuery1.Open;
                ClientDataSet1.Active := true;
      end;
    8:
      begin
        ClientDataSet1.Active := false;
         SQLQuery1.Close;
          SQLQuery1.SQL.Clear;
           SQLQuery1.SQL.Add('SELECT DISTINCT Dinozavr_Main.ID, Eda, Otryd, Period, Dinozavr, Text FROM ');
            SQLQuery1.SQL.Add('Dinozavr_Main, Period, Otryd, Eda, Epoha WHERE Dinozavr_Main.ID_Eda = Eda.ID ');
             SQLQuery1.SQL.Add('AND Dinozavr_Main.ID_Otryd = Otryd.ID AND Dinozavr_Main.ID_Period = Period.ID ');
              SQLQuery1.SQL.Add('AND Period.ID = 9');
               SQLQuery1.Open;
                ClientDataSet1.Active := true;
      end;
    9:
      begin
        ClientDataSet1.Active := false;
         SQLQuery1.Close;
          SQLQuery1.SQL.Clear;
           SQLQuery1.SQL.Add('SELECT DISTINCT Dinozavr_Main.ID, Eda, Otryd, Period, Dinozavr, Text FROM ');
            SQLQuery1.SQL.Add('Dinozavr_Main, Period, Otryd, Eda, Epoha WHERE Dinozavr_Main.ID_Eda = Eda.ID ');
             SQLQuery1.SQL.Add('AND Dinozavr_Main.ID_Otryd = Otryd.ID AND Dinozavr_Main.ID_Period = Period.ID ');
              SQLQuery1.SQL.Add('AND Period.ID = 10 ');
               SQLQuery1.Open;
                ClientDataSet1.Active := true;
      end;
  end;
end;

procedure TFormDinozavr.Helper1Click(Sender: TObject);
begin
  ShellExecute (FormDinozavr.Handle, nil, 'iexplore', 'https://https://thedrakoneragoni.wixsite.com/helper/', nil, SW_RESTORE);
end;

procedure TFormDinozavr.Image1Click(Sender: TObject);
begin
  FormDinozavr.Hide;
  LogOut.Show;
end;

procedure TFormDinozavr.N4Click(Sender: TObject);
begin
  FormDinozavr.Close;
end;

end.
