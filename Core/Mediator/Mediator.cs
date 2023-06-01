using System;
using System.Collections.ObjectModel;
using Electronic_archive_of_design_and_construction_documents.Models;
using Microsoft.VisualBasic.CompilerServices;

namespace Electronic_archive_of_design_and_construction_documents.Core.Mediator;

public class Mediator
{
    public event Action<Project> ProjectCreate;
    public event Action<Docs_of_product> ProductCreate;
    public event Action<Document> DocumentCreate;
    
    
    public event Action<Project> SelectedProject;
    public event Action<Docs_of_product> SelectedProduct;
    public event Action<Document> SelectedDocument;
    
    
    public event Action<object> SelectedViewModel;
    public event Action<object> SelectedDocumentTypeViewModel;
    
    public event Action<User> UserCreate; 
    public event Action<ObservableCollection<Role>> RoleCreate; 
    
    public void OnRoleCreate(ObservableCollection<Role> roles)
    {
        RoleCreate.Invoke(roles);
    }
    public void OnUserCreate(User user)
    {
        UserCreate.Invoke(user);
    }
    public void OnProjectCreation(Project project)
    {
        ProjectCreate.Invoke(project);
    }
    public void OnProductCreate(Docs_of_product product)
    {
        ProductCreate.Invoke(product);
    }
    public void OnDocumentCreate(Document document)
    {
        DocumentCreate.Invoke(document);
    }
    
    public void OnSelectedProjectChange(Project project)
    {
        SelectedProject.Invoke(project);
    } 
    public void OnSelectedProductChange(Docs_of_product product)
    {
        SelectedProduct.Invoke(product);
    }
    public void OnSelectedDocumentChange(Document document)
    {
        SelectedDocument.Invoke(document);
    }
    public void OnViewModelChange(Object obj)
    {
        SelectedViewModel.Invoke(obj);
    }
    public void OnSelectedDocumentTypeViewModelChange(Object obj)
    {
        SelectedDocumentTypeViewModel.Invoke(obj);
    }
}