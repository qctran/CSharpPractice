https://www.youtube.com/watch?v=ZfBy2nfykqY&t=714s

1. Add Prism.Cord Nuget - Bindable classes, Aggregate Commands...
	a. use BindableBase
	b. SetProperty()
2. Add Prism.Wpf - ViewModel locator
	a. add the followings to each view -
		xmlns:prism="http://prismlibrary.com/"
        prism:ViewModelLocator.AutoWireViewModel="True"
3. Add Prism.Unity - Dependency Injection unity to resolve type
	a. add a new class - bootstrapper.cs
