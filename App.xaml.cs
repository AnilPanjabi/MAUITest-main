﻿namespace MAUITest;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
        this.RegisterApplicationRoutes();
    }
}

