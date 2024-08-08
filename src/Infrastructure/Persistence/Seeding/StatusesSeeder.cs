using InventoryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Infrastructure.Persistence.Seeding;

public static class StatusesSeeder
{
	public static async Task SeedAsync(ApplicationDbContext context, CancellationToken cancellationToken)
	{
        Console.WriteLine("Seeding statuses");

        var pendingMigrations = await context.Database.GetPendingMigrationsAsync(cancellationToken);

		if (pendingMigrations.Any())
		{
			await context.Database.MigrateAsync(cancellationToken);
		}

		if (!context.Statuses.Any())
		{
			var newStatuses = new List<Status>();

			// Creating the In Stock statuses
			var inStockStatus = Status.Create("In Stock");
			var inStockAvailable = Status.Create("Available", "Items are in the warehouse and ready to be sold or used", inStockStatus);
			var inStockReserved = Status.Create("Reserved", "Items are in stock but reserved for a specific order or purpose", inStockStatus);
			var inStockAllocated = Status.Create("Allocated", "Items are assigned to an order but not yet picked or shipped", inStockStatus);
			var inStockOnHold = Status.Create("On Hold", " Items are in stock but cannot be used due to quality checks, payment issues, or other reasons", inStockStatus);
			newStatuses.AddRange([inStockStatus, inStockAvailable, inStockReserved, inStockAllocated, inStockOnHold]);


			// Creating the Out of Stock statuses
			var outOfStockStatus = Status.Create("Out of Stock");
			var outOfStockBackOrderered = Status.Create("Backordered", "Items are out of stock but on order from a supplier or manufacturer", outOfStockStatus);
			var outOfStockReorderPending = Status.Create("Reorder Pending", "Items are out of stock and a reorder request has been initiated", outOfStockStatus);
			var outOfStockDiscontinued = Status.Create("Discontinued", "Items are no longer available and will not be restocked", outOfStockStatus);
			newStatuses.AddRange([outOfStockStatus, outOfStockBackOrderered, outOfStockReorderPending, outOfStockDiscontinued]);

			// Creating the In Transit statuses
			var inTransitStatus = Status.Create("In Transit");
			var inTransitShipped = Status.Create("Shipped", "Items have been shipped from the warehouse but have not yet arrived at their destination", inTransitStatus);
			var inTransitReceiving = Status.Create("Receiving", "Items are on their way to the warehouse but have not yet been received", inTransitStatus);
			var inTransitTransfer = Status.Create("Transfer", "Items are being moved from one location to another within the company", inTransitStatus);
			newStatuses.AddRange([inTransitStatus, inTransitShipped, inTransitReceiving, inTransitTransfer]);

			// Creating the Under Inspection statuses
			var underInspectionStatus = Status.Create("Under Inspection");
			var underInspectionQualityCheck = Status.Create("Quality Check", "Items are being inspected for quality before being added to available stock", underInspectionStatus);
			var underInspectionDamaged = Status.Create("Damaged", "Items have been found damaged and are awaiting a decision on how to handle them", underInspectionStatus);
			var underInspectionQuarantine = Status.Create("Quarantine", "Items are set aside due to potential quality issues or recall notices", underInspectionStatus);
			newStatuses.AddRange([underInspectionStatus, underInspectionQualityCheck, underInspectionDamaged, underInspectionQuarantine]);

			// Creating the In use statuses
			var inUseStatus = Status.Create("In Use");
			var inUseIssued = Status.Create("Issued", "Items have been issued for use in production, maintenance, or other purposes", inUseStatus);
			var inUseConsumed = Status.Create("Consumed", "Items have been used and are no longer in stock", inUseStatus);
			newStatuses.AddRange([inUseStatus, inUseIssued, inUseConsumed]);

			// Creatign the Returned statuses
			var returnedStatus = Status.Create("Returned");
			var returnedReturnedToStock = Status.Create("Returned to Stock", "Items returned by customers that are in good condition and added back to inventory", returnedStatus);
			var returnedReturnedToSupplier = Status.Create("Return to Supplier", "Items returned to the supplier due to defects or other reasons", returnedStatus);
			var returnedAwaitingReturn = Status.Create("Awaiting Return", "Items are set aside, awaiting processing for return to stock or to a vendor", returnedStatus);
			newStatuses.AddRange([returnedStatus, returnedReturnedToStock, returnedReturnedToSupplier, returnedAwaitingReturn]);

			// Creating the Pending statuses
			var pendingStatus = Status.Create("Pending");
			var pendingReceipt = Status.Create("Pending Receipt", "Items are expected but not yet received", pendingStatus);
			var pendingInspection = Status.Create("Pending Inspection", "Items received but awaiting inspection", pendingStatus);
			var pendingDisposal = Status.Create("Pending Disposal", "Items identified for disposal or write-off but not yet processed", pendingStatus);
			newStatuses.AddRange([pendingStatus, pendingReceipt, pendingInspection, pendingDisposal]);

			// Creating the Dispose statuses
			var disposeStatus = Status.Create("Disposed");
			var disposedScrapped = Status.Create("Scrapped", "Items have been disposed of due to damage or obsolescence", disposeStatus);
			var disposeObsolete = Status.Create("Written Off", "Items have been written off due to loss, theft, or other reasons", disposeStatus);
			newStatuses.AddRange([disposeStatus, disposedScrapped, disposeObsolete]);

			// Creating the special case statuses
			var specialCaseStatus = Status.Create("Special Case");
			var scConsignment = Status.Create("Consignment", "Items held on behalf of a supplier or customer, not owned by the company", specialCaseStatus);
			var scOnLoan = Status.Create("On Loan", "Items temporarily loaned out to another party", specialCaseStatus);
			var scSample = Status.Create("Sample", "Items used for sampling, demos, or testing", specialCaseStatus);
			newStatuses.AddRange([specialCaseStatus, scConsignment, scOnLoan, scSample]);

			await context.Statuses.AddRangeAsync(newStatuses, cancellationToken);
			await context.SaveChangesAsync(cancellationToken);
			
		}
		else
		{
			Console.WriteLine("Statuses already seeded");
		}
	}
}
