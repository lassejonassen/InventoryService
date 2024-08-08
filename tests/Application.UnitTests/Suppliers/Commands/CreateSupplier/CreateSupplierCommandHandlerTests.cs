using FluentAssertions;
using InventoryService.Application.Suppliers.Commands.CreateSupplier;
using InventoryService.Domain.Entities;
using InventoryService.Domain.Errors;
using InventoryService.Domain.Repositories;
using InventoryService.Domain.Shared;
using Moq;

namespace InventoryService.Application.UnitTests.Suppliers.Commands.CreateSupplier;

public class CreateSupplierCommandHandlerTests
{
	private readonly Mock<ISupplierRepository> _supplierRepositoryMock;
	private readonly Mock<IUnitOfWork> _unitOfWorkMock;

	public CreateSupplierCommandHandlerTests()
	{
		_supplierRepositoryMock = new Mock<ISupplierRepository>();
		_unitOfWorkMock = new Mock<IUnitOfWork>();
	}

	[Fact]
	public async Task Handle_Should_ReturnFailureResult_WhenNameIsNotUnique()
	{
		// Arrange
		var command = new CreateSupplierCommand(
			Name: "Supplier Name",
			Street: "Supplier Address",
			City: "Some city",
			State: null,
			PostalCode: "1234",
			Country: "Denmark",
			Phone: null,
			Email: null);

		_supplierRepositoryMock.Setup(
			x => x.IsNameUnique(
			It.IsAny<string>(), 
			It.IsAny<CancellationToken>()))
			.ReturnsAsync(false);

		var handler = new CreateSupplierCommandHandler(_supplierRepositoryMock.Object, _unitOfWorkMock.Object);

		// Act
		Result<Guid> result = await handler.Handle(command, default);

		// Assert
		result.IsFailure.Should().BeTrue();
		result.Error.Should().Be(DomainErrors.Supplier.SupplierAlreadyExists);
	}

	[Fact]
	public async Task Handle_Should_ReturnSuccessResult_WhenNameIsUnique()
	{
		var command = new CreateSupplierCommand(
			Name: "Supplier Name",
			Street: "Supplier Address",
			City: "Some city",
			State: null,
			PostalCode: "1234",
			Country: "Denmark",
			Phone: null,
			Email: null);

		_supplierRepositoryMock.Setup(
			x => x.IsNameUnique(
			It.IsAny<string>(),
			It.IsAny<CancellationToken>()))
			.ReturnsAsync(true);

		var handler = new CreateSupplierCommandHandler(_supplierRepositoryMock.Object, _unitOfWorkMock.Object);

		// Act
		Result<Guid> result = await handler.Handle(command, default);

		// Assert
		result.IsSuccess.Should().BeTrue();
		result.Value.Should().NotBeEmpty();
	}

	[Fact]
	public async Task Handle_Should_CallCreateOnRepository_WhenNameIsUnique()
	{
		var command = new CreateSupplierCommand(
			Name: "Supplier Name",
			Street: "Supplier Address",
			City: "Some city",
			State: null,
			PostalCode: "1234",
			Country: "Denmark",
			Phone: null,
			Email: null);

		_supplierRepositoryMock.Setup(
			x => x.IsNameUnique(
			It.IsAny<string>(),
			It.IsAny<CancellationToken>()))
			.ReturnsAsync(true);

		var handler = new CreateSupplierCommandHandler(_supplierRepositoryMock.Object, _unitOfWorkMock.Object);

		// Act
		Result<Guid> result = await handler.Handle(command, default);

		// Assert
		_supplierRepositoryMock.Verify(
			x => x.AddAsync(It.Is<Supplier>(s => s.Id == result.Value), default),
			Times.Once);
	}

	[Fact]
	public async Task Handle_Should_NotCallUnitOfWork_WhenNameIsNotUnique()
	{
		// Arrange
		var command = new CreateSupplierCommand(
			Name: "Supplier Name",
			Street: "Supplier Address",
			City: "Some city",
			State: null,
			PostalCode: "1234",
			Country: "Denmark",
			Phone: null,
			Email: null);

		_supplierRepositoryMock.Setup(
			x => x.IsNameUnique(
			It.IsAny<string>(),
			It.IsAny<CancellationToken>()))
			.ReturnsAsync(false);

		var handler = new CreateSupplierCommandHandler(_supplierRepositoryMock.Object, _unitOfWorkMock.Object);

		// Act
		await handler.Handle(command, default);

		// Assert
		_unitOfWorkMock.Verify(
			x => x.SaveChangesAsync(It.IsAny<CancellationToken>()),
			Times.Never);
	}
}
